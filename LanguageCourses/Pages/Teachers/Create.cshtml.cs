using Microsoft.AspNetCore.Mvc;
using LanguageCourses.Data;
using LanguageCourses.Models;
using Microsoft.EntityFrameworkCore;

namespace LanguageCourses.Pages.Teachers
{
    public class CreateModel : TeacherCoursesPageModel
    {
        private readonly LanguageContext _context;
        private readonly ILogger<TeacherCoursesPageModel> _logger;

        public CreateModel(LanguageContext context, ILogger<TeacherCoursesPageModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult OnGet()
        {
            var teacher = new Teacher();
            teacher.Courses = new List<TeacherCourse>();

            PopulateAssignedCourseData(_context, teacher);
            return Page();
        }

        [BindProperty]
        public Teacher Teacher { get; set; } 
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(string[] selectedCourses)
        {
            var newTeacher = new Teacher();

            if (selectedCourses.Length > 0) 
            {
                newTeacher.Courses = new List<TeacherCourse>();

                _context.Courses.Load();
            }

            foreach (var course in selectedCourses)
            {
                var courseInTable = await _context.Courses.FindAsync(int.Parse(course));
                
                if (courseInTable != null)
                {
                    TeacherCourse foundCourse = new TeacherCourse
                    {
                        CourseID = courseInTable.CourseID,
                        TeacherID = newTeacher.TeacherID,
                        Course = courseInTable,
                        Teacher = newTeacher
                    };
                    newTeacher.Courses.Add(foundCourse);
                }
                else
                {
                    _logger.LogWarning("Course {course} not found", course);
                }
            }

            try
            {
                if (await TryUpdateModelAsync<Teacher>(
                    newTeacher,
                    "Teacher",
                    t => t.Surname, t => t.Name, t => t.LastName,
                    t => t.Education, t => t.DateStartTeaching))
                {
                    _context.Teachers.Add(newTeacher);
                    await _context.SaveChangesAsync();
                    return RedirectToPage("./Index");
                }
                return RedirectToPage("./Index");
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex.Message);
            }

            PopulateAssignedCourseData(_context, newTeacher);
            return Page();
        }
    }
}
