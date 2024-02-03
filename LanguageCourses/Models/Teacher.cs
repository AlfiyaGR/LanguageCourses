using System.ComponentModel.DataAnnotations;

namespace LanguageCourses.Models
{
    public class Teacher
    {
        public int TeacherID { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Фамилия")]
        public string Surname { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Имя")]
        public string Name { get; set; }

        [StringLength(100)]
        [Display(Name = "Отчество")]
        public string LastName { get; set; }

        [Display(Name = "Образование")]
        public string Education { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name =  "Начало преподавания")]
        public DateTime DateStartTeaching { get; set; }

        public ICollection<TeacherCourse>? Courses { get; set; }
    }
}
