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
    public class DeleteModel : PageModel
    {
        private readonly LanguageCourses.Data.LanguageContext _context;
        private readonly ILogger<DeleteModel> _logger;

        public DeleteModel(LanguageContext context, ILogger<DeleteModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        [BindProperty]
        public Review? Review { get; set; }
        public string ErrorMessage { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id, bool? saveChangesError = false)
        {
            if (id == null || _context.Reviews == null)
            {
                return NotFound();
            }

            Review = await _context.Reviews
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ReviewID == id);

            if (Review == null)
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
            if (id == null || _context.Reviews == null)
            {
                return NotFound();
            }

            var review = await _context.Reviews.FindAsync(id);

            if (review == null)
            {
                return NotFound();
            }

            try
            {
                _context.Reviews.Remove(review);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ErrorMessage);

                return RedirectToAction("./Delete",
                    new { id, saveChangesError = true });
            }
        }
    }
}
