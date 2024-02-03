using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LanguageCourses.Data;
using LanguageCourses.Models;

namespace LanguageCourses.Pages.Languages
{
    public class DetailsModel : PageModel
    {
        private readonly LanguageContext _context;

        public DetailsModel(LanguageContext context)
        {
            _context = context;
        }

      public Language Language { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Languages == null)
            {
                return NotFound();
            }

            var language = await _context.Languages
                .Include(lan => lan.Courses)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.LanguageID == id);

            if (language == null)
            {
                return NotFound();
            }
            else 
            {
                Language = language;
            }

            return Page();
        }
    }
}
