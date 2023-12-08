using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LanguageCourses.Data;
using LanguageCourses.Models;

namespace LanguageCourses.Pages.Languages
{
    public class DeleteModel : PageModel
    {
        private readonly LanguageContext _context;
        private readonly ILogger<DeleteModel> _logger;

        public DeleteModel(LanguageContext context, ILogger<DeleteModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        [BindProperty]
        public Language? Language { get; set; }
        public string ErrorMessage { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id, bool? saveChangesError = false)
        {
            if (id == null || _context.Languages == null)
            {
                return NotFound();
            }

            Language = await _context.Languages
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.LanguageID == id);

            if (Language == null)
            {
                return NotFound();
            }
            
            if (saveChangesError.GetValueOrDefault())
            {
                ErrorMessage = String.Format("Delete {ID} failed. Try again", id);
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Languages == null)
            {
                return NotFound();
            }

            var language = await _context.Languages.FindAsync(id);

            if (language == null)
            {
                return NotFound();
            }

            try
            {
                _context.Languages.Remove(language);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            catch (DbUpdateException ex) 
            {
                _logger.LogError(ex, ErrorMessage);

                return RedirectToAction("./Delete",
                    new { id, saveChangesError = true });
            }
        }
    }
}
