using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LanguageCourses.Data;
using LanguageCourses.Models;
using System.Configuration;

namespace LanguageCourses.Pages.Courses
{
    public class IndexModel : PageModel
    {
        private readonly LanguageContext _context;
        private readonly IConfiguration Configuration;

        public IndexModel(LanguageContext context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
        }

        public string TitleSort { get; set; }
        public string PriceSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public PaginatedList<Course> Courses { get;set; }

        public async Task OnGetAsync(string sortOrder,
            string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            TitleSort = string.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            PriceSort = sortOrder == "Price" ? "price_desc" : "Price";
            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;

            IQueryable<Course> coursesIQ = (from c in _context.Courses
                                            select c)
                                             .Include(c => c.Language);

            if (!string.IsNullOrEmpty(searchString))
            {
                coursesIQ = coursesIQ.Where(c => c.Title.Contains(searchString)
                        || c.Theme.Contains(searchString) || c.TrainingLevel.Contains(searchString)
                        || c.Language.Title.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "title_desc":
                    coursesIQ = coursesIQ.OrderByDescending(c => c.Title);
                    break;
                case "Price":
                    coursesIQ = coursesIQ.OrderBy(c => c.Price);
                    break;
                case "price_desc":
                    coursesIQ = coursesIQ.OrderByDescending(c => c.Price);
                    break;
                default:
                    coursesIQ = coursesIQ.OrderBy(c => c.Title);
                    break;
            }

            var pageSize = Configuration.GetValue("PageSize", 4);
            Courses = await PaginatedList<Course>.CreateAsync(
                coursesIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
