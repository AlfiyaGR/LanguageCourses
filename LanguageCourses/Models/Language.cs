using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace LanguageCourses.Models
{
    public class Language
    {
        public int LanguageID { get; set; }

        [Required]
        [Display(Name = "Язык")]
        public string Title { get; set; }

        [StringLength(30)]
        [Display(Name = "Сложность")]
        public string Complexity { get; set; }

        public ICollection<Course>? Courses { get; set; }
    }
}
