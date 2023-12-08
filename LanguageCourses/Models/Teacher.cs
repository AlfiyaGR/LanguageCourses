namespace LanguageCourses.Models
{
    public class Teacher
    {
        public int TeacherID { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Education { get; set; }
        public DateTime DateStartTeaching { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public ICollection<TeacherCourse> Courses { get; set; }
    }
}
