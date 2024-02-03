using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LanguageCourses.Data;
using LanguageCourses.Models;

namespace LanguageCourses.Pages.Teachers
{
    public class DetailsModel : PageModel
    {
        private readonly LanguageContext _context;

        public DetailsModel(LanguageContext context)
        {
            _context = context;
        }

      public Teacher Teacher { get; set; } 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Teachers == null)
            {
                return NotFound();
            }

            var teacher = await _context.Teachers
                .Include(t => t.Courses)
                .ThenInclude(c => c.Course)
                .ThenInclude(c => c.Language)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.TeacherID == id);

            if (teacher == null)
            {
                return NotFound();
            }
            else 
            {
                Teacher = teacher;
            }

            return Page();
        }
    }
}
