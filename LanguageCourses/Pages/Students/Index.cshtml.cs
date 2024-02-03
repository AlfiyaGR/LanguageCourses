using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LanguageCourses.Data;
using LanguageCourses.Models;

namespace LanguageCourses.Pages.Students
{
    public class IndexModel : PageModel
    {
        private readonly LanguageContext _context;

        public IndexModel(LanguageContext context)
        {
            _context = context;
        }

        public IList<Student> Student { get;set; } 

        public async Task OnGetAsync()
        {
            if (_context.Students != null)
            {
                Student = await _context.Students
                    .AsNoTracking()
                    .ToListAsync();
            }
        }
    }
}
