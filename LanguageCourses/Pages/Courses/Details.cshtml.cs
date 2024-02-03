using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LanguageCourses.Data;
using LanguageCourses.Models;

namespace LanguageCourses.Pages.Courses
{
    public class DetailsModel : PageModel
    {
        private readonly LanguageContext _context;

        public DetailsModel(LanguageContext context)
        {
            _context = context;
        }

        public Course Course { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Courses == null)
            {
                return NotFound();
            }

            var course = await _context.Courses
                .Include(c => c.Language)
                .Include(c => c.Reviews)
                .Include(c => c.Teachers)
                .ThenInclude(t => t.Teacher)
                .Include(c => c.Students)
                .ThenInclude(s => s.Student)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.CourseID == id);

            if (course == null)
            {
                return NotFound();
            }
            else 
            {
                Course = course;
            }

            return Page();
        }
    }
}
