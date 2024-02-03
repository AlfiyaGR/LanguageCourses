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
    public class DeleteModel : PageModel
    {
        private readonly LanguageContext _context;

        public DeleteModel(LanguageContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Teacher Teacher { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Teachers == null)
            {
                return NotFound();
            }

            var teacher = await _context.Teachers
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Teachers == null)
            {
                return NotFound();
            }
            Teacher = await _context.Teachers
                .Include(t => t.Courses)
                .SingleAsync(t => t.TeacherID == id);

            if (Teacher == null)
            {
                return RedirectToPage("./Index");
            }

            _context.Teachers.Remove(Teacher);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
