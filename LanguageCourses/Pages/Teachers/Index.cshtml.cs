using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LanguageCourses.Data;
using LanguageCourses.Models;

namespace LanguageCourses.Pages.Teachers
{
    public class IndexModel : PageModel
    {
        private readonly LanguageContext _context;

        public IndexModel(LanguageContext context)
        {
            _context = context;
        }

        public IList<Teacher> Teacher { get;set; }

        public async Task OnGetAsync()
        {
            if (_context.Teachers != null)
            {
                Teacher = await _context.Teachers
                    .AsNoTracking()
                    .ToListAsync();
            }
        }
    }
}
