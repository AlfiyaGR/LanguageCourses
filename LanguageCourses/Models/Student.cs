namespace LanguageCourses.Models
{
    public class Student
    {
        public string StudentID { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Level { get; set; }
        public string Hobby { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public ICollection<StudentCourse> Courses { get; set; }
    }
}
