using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using LanguageCourses.Data;
using LanguageCourses.Models;
using LanguageCourses.Pages.Teachers;
using Microsoft.EntityFrameworkCore;

namespace LanguageCourses.Pages.Students
{
    public class CreateModel : StudentsCoursesPageModel
    {
        private readonly LanguageContext _context;
        private readonly ILogger<StudentsCoursesPageModel> _logger;

        public CreateModel(LanguageContext context, ILogger<StudentsCoursesPageModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult OnGet()
        {
            var student = new Student();
            student.Courses = new List<StudentCourse>();

            PopulateAssignedCourseData(_context, student);
            return Page();
        }

        [BindProperty]
        public Student Student { get; set; } 
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(string[] selectedCourses)
        {
            var newStudent = new Student();

            if (selectedCourses.Length > 0)
            {
                newStudent.Courses = new List<StudentCourse>();

                _context.Courses.Load();
            }

            foreach (var course in selectedCourses)
            {
                var courseInTable = await _context.Courses.FindAsync(int.Parse(course));

                if (courseInTable != null)
                {
                    StudentCourse foundCourse = new StudentCourse
                    {
                        CourseID = courseInTable.CourseID,
                        StudentID = newStudent.StudentID,
                        Course = courseInTable,
                        Student = newStudent
                    };

                    newStudent.Courses.Add(foundCourse);

                }
                else
                {
                    _logger.LogWarning("Course {course} not found", course);

                }
            }

            try
            {
                if (await TryUpdateModelAsync<Student>(
                    newStudent,
                    "Student",
                    s => s.Surname, s => s.Name, s => s.LastName,
                    s => s.BirthDate, s => s.Level, s => s.Hobby))
                {
                    _context.Students.Add(newStudent);
                    await _context.SaveChangesAsync();
                    return RedirectToPage("./Index");
                }
                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            PopulateAssignedCourseData(_context, newStudent);
            return Page();
        }
    }
}
