using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LanguageCourses.Data;
using LanguageCourses.Models;

namespace LanguageCourses.Pages.Languages
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
        public string ComplexitySort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public PaginatedList<Language> Languages { get;set; }

        public async Task OnGetAsync(string sortOrder, 
            string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            TitleSort = string.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            ComplexitySort = sortOrder == "Complexity" ? "complexity_desc" : "Complexity";
            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;

            IQueryable<Language> languagesIQ = from lan in _context.Languages
                                               select lan;

            if (!string.IsNullOrEmpty(searchString))
            {
                languagesIQ = languagesIQ.Where(lan => lan.Title.Contains(searchString)
                        || lan.Complexity.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "title_desc":
                    languagesIQ = languagesIQ.OrderByDescending(lan => lan.Title);
                    break;
                case "Complexity":
                    languagesIQ = languagesIQ.OrderBy(lan => lan.Complexity);
                    break;
                case "complexity_desc":
                    languagesIQ = languagesIQ.OrderByDescending(lan => lan.Complexity);
                    break;
                default:
                    languagesIQ = languagesIQ.OrderBy(lan => lan.Title);
                    break;
            }

            var pageSize = Configuration.GetValue("PageSize", 4);
            Languages = await PaginatedList<Language>.CreateAsync(
                languagesIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
