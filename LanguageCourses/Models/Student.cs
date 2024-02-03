using System.ComponentModel.DataAnnotations;

namespace LanguageCourses.Models
{
    public class Student
    {
        public int StudentID { get; set; }

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


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Дата рождения")]
        public DateTime BirthDate { get; set; }

        [StringLength(30)]
        [Display(Name = "Уровень")]
        public string Level { get; set; }

        [Display(Name = "Увлечения")]
        public string Hobby { get; set; }

        public ICollection<StudentCourse>? Courses { get; set; }
    }
}
