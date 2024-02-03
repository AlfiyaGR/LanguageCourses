using LanguageCourses.Data;
using LanguageCourses.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LanguageCourses.Pages.Reviews
{
    public class CourseTitlePageModel : PageModel
    {
        public SelectList CourseTitleSL { get; set; }

        public void PopulateCourseDropDownList(LanguageContext _context,
           object selectedCourse = null)
        {
            var coursesQuery = from c in _context.Courses
                                 orderby c.Title
                                 select c;

            CourseTitleSL = new SelectList(coursesQuery.AsNoTracking(),
                nameof(Course.CourseID),
                nameof(Course.Title),
                selectedCourse);
        }
    }
}
