using LanguageCourses.Models;

namespace LanguageCourses.Data
{
    public static class DbInitializer
    {
        public static void Initialize(LanguageContext context)
        {
            if (context.Languages.Any())
                return;

            var languages = new Language[]
            {
                new Language{ Title="English", Complexity="Easy" },
                new Language{ Title="Chinese", Complexity="Hard" },
                new Language{ Title="Korean", Complexity="Medium" },
                new Language{ Title="Turkish", Complexity="Easy" }
            };

            context.Languages.AddRange(languages);
            context.SaveChanges();

            var courses = new Course[]
            {
                new Course{ 
                    Title="Easy Korean", 
                    Theme="Speaking", 
                    Price=4000, 
                    TrainingLevel="Start", 
                    Time=DateTime.Parse("2023-12-12"), 
                    LanguageID=3
                },
                new Course{
                    Title="English Master",
                    Theme="Grammatics",
                    Price=6000,
                    TrainingLevel="Master",
                    Time=DateTime.Parse("2024-1-21"),
                    LanguageID=1
                },
                new Course{
                    Title="Start with Li Hua",
                    Theme="Base in language",
                    Price=3000,
                    TrainingLevel="Start",
                    Time=DateTime.Parse("2024-4-12"),
                    LanguageID=2
                },
                new Course{
                    Title="How understand Turkish?",
                    Theme="Features of colloquial speech",
                    Price=5000,
                    TrainingLevel="Medium-Master",
                    Time=DateTime.Parse("2024-2-15"),
                    LanguageID=4
                },
                new Course{
                    Title="Chinese heart",
                    Theme="History",
                    Price=3500,
                    TrainingLevel="Start-Medium-Hard",
                    Time=DateTime.Parse("2023-3-11"),
                    LanguageID=2
                }
            };

            context.Courses.AddRange( courses );
            context.SaveChanges();
        }
    }
}
