using LanguageCourses.Data;
using LanguageCourses.Models.ViewModels;
using LanguageCourses.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LanguageCourses.Pages.Students
{
    public class StudentsCoursesPageModel : PageModel
    {
        public List<AssignedCourseData> AssignedCourseDataList;

        public void PopulateAssignedCourseData(LanguageContext context,
            Student student)
        {
            var allCourses = context.Courses;
            var studentCourses = new HashSet<int>(
                student.Courses.Select(c => c.CourseID));

            AssignedCourseDataList = new List<AssignedCourseData>();

            foreach (var course in allCourses)
            {
                AssignedCourseDataList.Add(new AssignedCourseData
                {
                    CourseID = course.CourseID,
                    Title = course.Title,
                    Assigned = studentCourses.Contains(course.CourseID)
                });
            }
        }
    }
}
