using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using LanguageCourses.Data;
using LanguageCourses.Models;

namespace LanguageCourses.Pages.Courses
{
    public class CreateModel : LanguageTitlePageModel
    {
        private readonly LanguageContext _context;

        public CreateModel(LanguageContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            PopulateLanguageDropDownList(_context);
            return Page();
        }

        [BindProperty]
        public Course Course { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            var emptyCourse = new Course();

            if (await TryUpdateModelAsync<Course>(
                emptyCourse,
                "course",
                c => c.LanguageID, c => c.Title, c => c.Theme,
                c => c.Price, c => c.TrainingLevel, c => c.Time
                ))
            {
                _context.Courses.Add(emptyCourse);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            PopulateLanguageDropDownList(_context, emptyCourse.LanguageID);
            return Page();
        }
    }
}
