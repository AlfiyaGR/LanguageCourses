using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using LanguageCourses.Data;
using LanguageCourses.Models;

namespace LanguageCourses.Pages.Languages
{
    public class CreateModel : PageModel
    {
        private readonly LanguageCourses.Data.LanguageContext _context;

        public CreateModel(LanguageCourses.Data.LanguageContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Language Language { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Languages == null || Language == null)
            {
                return Page();
            }

            var emptyLanguage = new Language();

            if (await TryUpdateModelAsync<Language>(
                emptyLanguage,
                "Language",
                lan => lan.Title, lan => lan.Complexity))
            {
                _context.Languages.Add(emptyLanguage);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
