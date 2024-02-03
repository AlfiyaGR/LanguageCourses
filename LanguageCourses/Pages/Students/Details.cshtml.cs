using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LanguageCourses.Data;
using LanguageCourses.Models;

namespace LanguageCourses.Pages.Students
{
    public class DetailsModel : PageModel
    {
        private readonly LanguageCourses.Data.LanguageContext _context;

        public DetailsModel(LanguageCourses.Data.LanguageContext context)
        {
            _context = context;
        }

      public Student Student { get; set; } 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Students == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .Include(s => s.Courses)
                .ThenInclude(c => c.Course)
                .ThenInclude(c => c.Language)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.StudentID == id);
            
            if (student == null)
            {
                return NotFound();
            }
            else 
            {
                Student = student;
            }

            return Page();
        }
    }
}
