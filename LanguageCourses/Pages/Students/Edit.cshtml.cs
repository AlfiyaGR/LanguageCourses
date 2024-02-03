using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LanguageCourses.Models;

namespace LanguageCourses.Pages.Students
{
    public class EditModel : StudentsCoursesPageModel
    {
        private readonly Data.LanguageContext _context;

        public EditModel(Data.LanguageContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Student Student { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Students == null)
            {
                return NotFound();
            }

            Student = await _context.Students
                .Include(t => t.Courses)
                .ThenInclude(c => c.Course)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.StudentID == id);

            if (Student == null)
            {
                return NotFound();
            }

            PopulateAssignedCourseData(_context, Student);
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id,
            string[] selectedCourses)
        {
            if (id == null)
                return NotFound();

            var studentToUpdate = await _context.Students
                .Include(t => t.Courses)
                .ThenInclude(c => c.Course)
                .FirstOrDefaultAsync(t => t.StudentID == id);

            if (studentToUpdate == null)
                return NotFound();

            if (await TryUpdateModelAsync<Student>(
                studentToUpdate,
                "Student",
                s => s.Surname, s => s.Name, s => s.LastName,
                s => s.BirthDate, s => s.Level, s => s.Hobby))
            {
                UpdateStudentCourses(selectedCourses, studentToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            UpdateStudentCourses(selectedCourses, studentToUpdate);
            PopulateAssignedCourseData(_context, studentToUpdate);
            return Page();
        }

        public void UpdateStudentCourses(string[] selectedCourses,
            Student studentToUpdate)
        {
            if (selectedCourses == null || selectedCourses.Count() == 0)
            {
                studentToUpdate.Courses = new List<StudentCourse>();
                return;
            }

            var selectedCoursesHS = new HashSet<string>(selectedCourses);
            var studentCourses = new HashSet<int>
                (studentToUpdate.Courses.Select(c => c.CourseID));

            foreach (var course in _context.Courses)
            {
                if (selectedCoursesHS.Contains(course.CourseID.ToString()))
                {
                    if (!studentCourses.Contains(course.CourseID))
                    {
                        studentToUpdate.Courses.Add(new StudentCourse 
                        { 
                            CourseID = course.CourseID,
                            StudentID = studentToUpdate.StudentID,
                            Course = course,
                            Student = studentToUpdate
                        });
                    }
                }
                else
                {
                    if (studentCourses.Contains(course.CourseID))
                    {
                        var courseToRemove = studentToUpdate.Courses.Single(
                                                        c => c.CourseID == course.CourseID);
                        studentToUpdate.Courses.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}