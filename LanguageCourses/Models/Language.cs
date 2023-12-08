namespace LanguageCourses.Models
{
    public class Language
    {
        public int LanguageID { get; set; }
        public string Title { get; set; }
        public string Complexity { get; set; }

        public ICollection<Course>? Courses { get; set; }
    }
}
