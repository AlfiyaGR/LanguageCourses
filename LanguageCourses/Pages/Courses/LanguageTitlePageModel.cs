using LanguageCourses.Data;
using LanguageCourses.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LanguageCourses.Pages.Courses
{
    public class LanguageTitlePageModel : PageModel
    {
        public SelectList LanguageTitleSL { get; set; }

        public void PopulateLanguageDropDownList(LanguageContext _context, 
            object selectedLanguage = null)
        {
            var languagesQuery = from lan in _context.Languages
                                 orderby lan.Title
                                 select lan;

            LanguageTitleSL = new SelectList(languagesQuery.AsNoTracking(), 
                nameof(Language.LanguageID),
                nameof(Language.Title),
                selectedLanguage);
        }
    }
}
