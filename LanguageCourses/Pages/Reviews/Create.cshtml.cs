using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using LanguageCourses.Data;
using LanguageCourses.Models;
using Microsoft.EntityFrameworkCore;
using LanguageCourses.Pages.Courses;

namespace LanguageCourses.Pages.Reviews
{
    public class CreateModel : CourseTitlePageModel
    {
        private readonly LanguageContext _context;

        public CreateModel(LanguageContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            PopulateCourseDropDownList(_context);
            return Page();
        }

        [BindProperty]
        public Review Review { get; set; }
        
        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            var emptyReview = new Review();

            if (await TryUpdateModelAsync<Review>(
                emptyReview,
                "Review",
                r => r.Author, r => r.Text, r => r.Evaluation, r => r.CourseID))
            {
                _context.Reviews.Add(emptyReview);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            PopulateCourseDropDownList(_context, emptyReview.CourseID);
            return Page();
        }
    }
}
