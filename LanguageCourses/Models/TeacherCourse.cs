namespace LanguageCourses.Models
{
    public class TeacherCourse
    {
        public int Id { get; set; }
        public int TeacherID { get; set; }
        public int CourseID { get; set; }

        public Teacher? Teacher { get; set; }
        public Course? Course { get; set;}
    }
}
