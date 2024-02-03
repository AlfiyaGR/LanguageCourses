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
    public class DetailsModel : PageModel
    {
        private readonly LanguageCourses.Data.LanguageContext _context;

        public DetailsModel(LanguageCourses.Data.LanguageContext context)
        {
            _context = context;
        }

        public Review Review { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Reviews == null)
            {
                return NotFound();
            }

            Review = await _context.Reviews
                .Include(r => r.Course)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ReviewID == id);

            if (Review == null)
            {
                return NotFound();
            }
            
            return Page();
        }
    }
}
