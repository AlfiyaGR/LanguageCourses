using System.ComponentModel.DataAnnotations;

namespace LanguageCourses.Models
{
    public class Review
    {
        public int ReviewID { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Автор")]
        public string Author { get; set; }

        [Display(Name = "Текст")]
        public string Text { get; set; }

        [Required]
        [Range(0, 10)]
        [Display(Name = "Оценка")]
        public int Evaluation { get; set; }

        public int CourseID { get; set; }

        public Course? Course { get; set; }

    }
}
