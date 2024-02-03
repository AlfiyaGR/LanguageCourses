using LanguageCourses.Data;
using LanguageCourses.Models;
using LanguageCourses.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LanguageCourses.Pages.Teachers
{
    public class TeacherCoursesPageModel : PageModel
    {
        public List<AssignedCourseData> AssignedCourseDataList;

        public void PopulateAssignedCourseData(LanguageContext context,
            Teacher teacher)
        {
            var allCourses = context.Courses;
            var teacherCourses = new HashSet<int>(
                teacher.Courses.Select(c => c.CourseID));

            AssignedCourseDataList = new List<AssignedCourseData>();

            foreach (var course in allCourses)
            {
                AssignedCourseDataList.Add(new AssignedCourseData
                {
                    CourseID = course.CourseID,
                    Title = course.Title,
                    Assigned = teacherCourses.Contains(course.CourseID)
                });
            }
        }
    }
}
