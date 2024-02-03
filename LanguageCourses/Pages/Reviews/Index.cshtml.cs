using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LanguageCourses.Data;
using LanguageCourses.Models;

namespace LanguageCourses.Pages.Reviews
{
    public class IndexModel : PageModel
    {
        private readonly LanguageContext _context;

        public IndexModel(LanguageContext context)
        {
            _context = context;
        }

        public IList<Review> Review { get;set; } 

        public async Task OnGetAsync()
        {
            if (_context.Reviews != null)
            {
                Review = await _context.Reviews
                    .Include(r => r.Course)
                    .ToListAsync();
            }
        }
    }
}
