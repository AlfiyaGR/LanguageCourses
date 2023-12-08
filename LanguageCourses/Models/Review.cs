namespace LanguageCourses.Models
{
    public class Review
    {
        public int ReviewID { get; set; }
        public int CourseID { get; set; }
        public string Author { get; set; }
        public string Text { get; set; }
        public string Evaluation { get; set; }

    }
}
