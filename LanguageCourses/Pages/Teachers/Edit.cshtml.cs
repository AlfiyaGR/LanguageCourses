using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LanguageCourses.Data;
using LanguageCourses.Models;

namespace LanguageCourses.Pages.Teachers
{
    public class EditModel : TeacherCoursesPageModel
    {
        private readonly LanguageContext _context;

        public EditModel(LanguageContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Teacher Teacher { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Teachers == null)
            {
                return NotFound();
            }

            Teacher =  await _context.Teachers
                .Include(t => t.Courses)
                .ThenInclude(c => c.Course)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.TeacherID == id);
            
            if (Teacher == null)
            {
                return NotFound();
            }

            PopulateAssignedCourseData(_context, Teacher);
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id,
            string[] selectedCourses)
        {
            if (id == null)
                return NotFound();

            var teacherToUpdate = await _context.Teachers
                .Include(t => t.Courses)
                .ThenInclude(c => c.Course)
                .FirstOrDefaultAsync(t => t.TeacherID == id);

            if (teacherToUpdate == null)
                return NotFound();

            if (await TryUpdateModelAsync<Teacher>(
                teacherToUpdate,
                "Teacher",
                t => t.Surname, t => t.Name, t => t.LastName,
                t => t.Education, t => t.DateStartTeaching))
            {
                UpdateTeacherCourses(selectedCourses, teacherToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            UpdateTeacherCourses(selectedCourses, teacherToUpdate);
            PopulateAssignedCourseData(_context, teacherToUpdate);
            return Page();
        }

        public void UpdateTeacherCourses(string[] selectedCourses,
            Teacher teacherToUpdate)
        {
            if (selectedCourses == null || selectedCourses.Count() == 0)
            {
                teacherToUpdate.Courses = new List<TeacherCourse>();
                return;
            }

            var selectedCoursesHS = new HashSet<string>(selectedCourses);
            var teacherCourses = new HashSet<int>
                (teacherToUpdate.Courses.Select(c => c.CourseID));

            foreach (var course in _context.Courses)
            {
                if (selectedCoursesHS.Contains(course.CourseID.ToString()))
                {
                    if (!teacherCourses.Contains(course.CourseID))
                    {
                        teacherToUpdate.Courses.Add(new TeacherCourse
                        {
                            CourseID = course.CourseID,
                            TeacherID = teacherToUpdate.TeacherID,
                            Course = course,
                            Teacher = teacherToUpdate
                        });
                    }
                }
                else
                {
                    if (teacherCourses.Contains(course.CourseID))
                    {
                        var courseToRemove = teacherToUpdate.Courses.Single(
                                                        c => c.CourseID == course.CourseID);
                        teacherToUpdate.Courses.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}
