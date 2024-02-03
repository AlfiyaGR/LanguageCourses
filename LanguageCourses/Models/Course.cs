using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LanguageCourses.Models
{
    public class Course
    {
        public int CourseID { get; set; }

        [Required]
        [Display(Name = "Название")]
        public string Title { get; set; }

        [StringLength(100)]
        [Display(Name = "Тема")]
        public string Theme { get; set; }

        [Range(0, 100000)]
        [Display(Name = "Цена")]
        public decimal Price { get; set; }

        [StringLength(30)]
        [Display(Name = "Уровень подготовки")]
        public string TrainingLevel { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Старт курса")]
        public DateTime Time { get; set; }

        public int LanguageID { get; set; }

        public Language? Language { get; set; }
        public ICollection<StudentCourse>? Students { get; set; }
        public ICollection<TeacherCourse>? Teachers { get; set; }
        public ICollection<Review>? Reviews { get; set; }
    }
}
