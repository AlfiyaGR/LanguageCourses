using LanguageCourses.Data;
using LanguageCourses.Models;
using LanguageCourses.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace LanguageCourses.Pages
{
    public class AboutModel : PageModel
    {
        private readonly LanguageContext _context;

        public AboutModel(LanguageContext Context)
        {
            _context = Context;
        }

        public IList<LanguageCourse> Languages { get; set; }
        public IList<CourseStudent> Students { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<LanguageCourse> languageData =
                from course in _context.Courses
                from language in _context.Languages
                where course.LanguageID == language.LanguageID
                group course by language.Title into languageGroup
                select new LanguageCourse()
                {
                    LanguageTitle = languageGroup.Key,
                    CoursesCount = languageGroup.Count(),
                }; 

            Languages = await languageData.AsNoTracking().ToListAsync();

            IQueryable<CourseStudent> studData =
                from studentCourse in _context.StudentCourse
                from course in _context.Courses
                from student in _context.Students
                where studentCourse.CourseID == course.CourseID && studentCourse.StudentID == student.StudentID
                group student by course.Title into courseGroup
                select new CourseStudent()
                {
                    CourseTitle = courseGroup.Key,
                    StudentsCount = courseGroup.Count()
                };


            Students = await studData.AsNoTracking().ToListAsync();
        }
    }
}
