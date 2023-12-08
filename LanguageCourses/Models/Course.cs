namespace LanguageCourses.Models
{
    public class Course
    {
        public int CourseID { get; set; }
        public string Title { get; set; }
        public string Theme { get; set; }
        public decimal Price { get; set; }
        public string TrainingLevel { get; set; }
        public DateTime Time { get; set; }
        public int LanguageID { get; set; }

        public ICollection<StudentCourse> Students { get; set; }
        public ICollection<TeacherCourse> Teachers { get; set; }
        public ICollection<Review>? Reviews { get; set; }
    }
}
