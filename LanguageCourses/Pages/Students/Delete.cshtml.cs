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
    public class DeleteModel : PageModel
    {
        private readonly LanguageCourses.Data.LanguageContext _context;

        public DeleteModel(LanguageCourses.Data.LanguageContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Student Student { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Students == null)
            {
                return NotFound();
            }

            var student = await _context.Students.FirstOrDefaultAsync(m => m.StudentID == id);

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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Students == null)
            {
                return NotFound();
            }

            Student = await _context.Students
                .Include(t => t.Courses)
                .SingleAsync(t => t.StudentID == id);

            if (Student == null)
            {
                return RedirectToPage("./Index");
            }

            _context.Students.Remove(Student);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
