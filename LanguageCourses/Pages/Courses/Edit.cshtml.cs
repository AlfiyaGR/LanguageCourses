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

namespace LanguageCourses.Pages.Courses
{
    public class EditModel : LanguageTitlePageModel
    {
        private readonly LanguageContext _context;

        public EditModel(LanguageContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Course Course { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Courses == null)
            {
                return NotFound();
            }

            Course =  await _context.Courses
                .Include(c => c.Language)
                .FirstOrDefaultAsync(m => m.CourseID == id);
            
            if (Course == null)
            {
                return NotFound();
            }

            PopulateLanguageDropDownList(_context, Course.LanguageID);
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseToUpdate = await _context.Courses.FindAsync(id);

            if (courseToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Course>(
                courseToUpdate,
                "course",
                c => c.LanguageID, c => c.Price, c => c.Title,
                c => c.Theme, c => c.Time, c => c.TrainingLevel))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            PopulateLanguageDropDownList(_context, courseToUpdate.LanguageID);
            return Page();
        }
    }
}
