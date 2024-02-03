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

namespace LanguageCourses.Pages.Reviews
{
    public class EditModel : CourseTitlePageModel
    {
        private readonly LanguageCourses.Data.LanguageContext _context;

        public EditModel(LanguageCourses.Data.LanguageContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Review Review { get; set; } 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Reviews == null)
            {
                return NotFound();
            }

            Review =  await _context.Reviews
                .Include(r => r.Course)
                .FirstOrDefaultAsync(m => m.ReviewID == id);

            if (Review == null)
            {
                return NotFound();
            }

            PopulateCourseDropDownList(_context, Review.CourseID);
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

            var reviewToUpdate = await _context.Reviews.FindAsync(id);

            if (reviewToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Review>(
                reviewToUpdate,
                "review",
                r => r.CourseID, r => r.Text, r => r.Evaluation, r => r.Author))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            PopulateCourseDropDownList(_context, reviewToUpdate.CourseID);
            return Page();
        }
    }
}
