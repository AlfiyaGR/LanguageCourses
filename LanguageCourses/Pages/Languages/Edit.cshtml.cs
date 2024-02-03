using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LanguageCourses.Data;
using LanguageCourses.Models;

namespace LanguageCourses.Pages.Languages
{
    public class EditModel : PageModel
    {
        private readonly LanguageContext _context;

        public EditModel(LanguageContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Language? Language { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Languages == null)
            {
                return NotFound();
            }

            Language = await _context.Languages.FindAsync(id);

            if (Language == null)
            {
                return NotFound();
            }
            
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            var languageToUpdate = await _context.Languages.FindAsync(id);

            if (languageToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Language>(
                languageToUpdate,
                "language",
                lan => lan.Title, lan => lan.Complexity))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
