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
                new Language{ Title="Английский", Complexity="Просто" },
                new Language{ Title="Китайский", Complexity="Сложно" },
                new Language{ Title="Корейский", Complexity="Средне" },
                new Language{ Title="Турецкий", Complexity="Просто" }
            };

            context.Languages.AddRange(languages);
            context.SaveChanges();

            var courses = new Course[]
            {
                new Course{
                    Title="Китайское сердце",
                    Theme="История",
                    Price=3500,
                    TrainingLevel="Базовый-Средний-Сложный уровни",
                    Time=DateTime.Parse("2023-3-11"),
                    LanguageID=2
                },
                new Course{
                    Title="Корейские песни",
                    Theme="Переводим песни айдолов",
                    Price=2000,
                    TrainingLevel="Средний уровень",
                    Time=DateTime.Parse("2024-2-15"),
                    LanguageID=3
                },
                new Course{
                    Title="Едем в Англию",
                    Theme="Разговорная речь. Традиции и особенности жизни",
                    Price=5000,
                    TrainingLevel="Мастер",
                    Time=DateTime.Parse("2024-2-15"),
                    LanguageID=1
                },
                new Course{
                    Title="Великолепный Турецкий?",
                    Theme="Великолепный Век в оригинале",
                    Price=1500,
                    TrainingLevel="Средний",
                    Time=DateTime.Parse("2024-2-15"),
                    LanguageID=4
                }
            };

            context.Courses.AddRange( courses );
            context.SaveChanges();

            var students = new Student[]
            {
                new Student
                {
                    Surname = "Аксенов",
                    Name = "Матвей",
                    LastName = "Олегович",
                    BirthDate = DateTime.Parse("1995-11-25"),
                    Level = "Начальный",
                    Hobby = "Музыка, кино, театр",
                },
                new Student
                {
                    Surname = "Архипов",
                    Name = "Сергей",
                    LastName = "Александрович",
                    BirthDate = DateTime.Parse("1993-4-1"),
                    Level = "Средний",
                    Hobby = "Театр, сериалы",
                },
                new Student
                {
                    Surname = "Афанасьев",
                    Name = "Матвей",
                    LastName = "Михайлович",
                    BirthDate = DateTime.Parse("1997-3-30"),
                    Level = "Средний-Высокий",
                    Hobby = "Мода, музыка",
                },
                new Student
                {
                    Surname = "Барсуков",
                    Name = "Алексей",
                    LastName = "Данилович",
                    BirthDate = DateTime.Parse("2000-2-27"),
                    Level = "Высокий",
                    Hobby = "Программирование",
                },
                new Student
                {
                    Surname = "Безрукова",
                    Name = "Валерия",
                    LastName = "Львовна",
                    BirthDate = DateTime.Parse("1983-9-11"),
                    Level = "Средний",
                    Hobby = "Готовка, сериалы",
                },
                new Student
                {
                    Surname = "Белова",
                    Name = "Василиса",
                    LastName = "Ивановна",
                    BirthDate = DateTime.Parse("2003-6-2"),
                    Level = "Начальный",
                    Hobby = "Дорамы, музыка, искуство",
                },
                new Student
                {
                    Surname = "Белова",
                    Name = "София",
                    LastName = "Платоновна",
                    BirthDate = DateTime.Parse("1990-12-12"),
                    Level = "Высокий",
                    Hobby = "Литература, путешествия",
                },
                new Student
                {
                    Surname = "Беляев",
                    Name = "Артём",
                    LastName = "Маркович",
                    BirthDate = DateTime.Parse("1987-2-23"),
                    Level = "Мастет",
                    Hobby = "Путешествия",
                },
                new Student
                {
                    Surname = "Борисов",
                    Name = "Матвей",
                    LastName = "Михайлович",
                    BirthDate = DateTime.Parse("2000-1-15"),
                    Level = "Начальный",
                    Hobby = "Мотоциклы, техника",
                },
                new Student
                {
                    Surname = "Быкова",
                    Name = "Полина",
                    LastName = "Макаровна",
                    BirthDate = DateTime.Parse("2003-3-15"),
                    Level = "Средний",
                    Hobby = "Мода, выступления, сцена",
                },
                new Student
                {
                    Surname = "Винокуров",
                    Name = "Максим",
                    LastName = "Даниилович",
                    BirthDate = DateTime.Parse("2000-2-19"),
                    Level = "Высокий",
                    Hobby = "Путешествия, техника, механизмы",
                },
                new Student
                {
                    Surname = "Винокурова",
                    Name = "Василиса",
                    LastName = "Антоновна",
                    BirthDate = DateTime.Parse("1995-12-1"),
                    Level = "Высокий",
                    Hobby = "Путешествия, машины",
                },
                new Student
                {
                    Surname = "Владимирова",
                    Name = "Алиса",
                    LastName = "Андреевна",
                    BirthDate = DateTime.Parse("2010-2-20"),
                    Level = "Начальный",
                    Hobby = "Математика, информатика, ИЗО",
                },
                new Student
                {
                    Surname = "Власова",
                    Name = "Мария",
                    LastName = "Михайловна",
                    BirthDate = DateTime.Parse("1999-12-9"),
                    Level = "Средний",
                    Hobby = "Литература, история, живопись",
                },
                new Student
                {
                    Surname = "Волошин",
                    Name = "Антон",
                    LastName = "Михайлович",
                    BirthDate = DateTime.Parse("2001-4-19"),
                    Level = "Средний",
                    Hobby = "История, музыка",
                },
                new Student
                {
                    Surname = "Воробьев",
                    Name = "Артём",
                    LastName = "Антонович",
                    BirthDate = DateTime.Parse("1989-3-29"),
                    Level = "Начальный",
                    Hobby = "Дизайн, архитектура, история",
                },
                new Student
                {
                    Surname = "Гаврилова",
                    Name = "Полина",
                    LastName = "Андреевна",
                    BirthDate = DateTime.Parse("1997-5-10"),
                    Level = "Высокий",
                    Hobby = "Путешествия, мода",
                },
                new Student
                {
                    Surname = "Гончаров",
                    Name = "Владимир",
                    LastName = "Денисович",
                    BirthDate = DateTime.Parse("1995-6-17"),
                    Level = "Средний",
                    Hobby = "Рисование, искусство",
                },
                new Student
                {
                    Surname = "Горелова",
                    Name = "Ангелина",
                    LastName = "Григорьевна",
                    BirthDate = DateTime.Parse("2009-10-19"),
                    Level = "Начальный",
                    Hobby = "История, механизмы",
                },
                new Student
                {
                    Surname = "Горохова",
                    Name = "Екатерина",
                    LastName = "Александровна",
                    BirthDate = DateTime.Parse("1996-6-18"),
                    Level = "Средний",
                    Hobby = "Языки, музыка, театр",
                },
                new Student
                {
                    Surname = "Грачев",
                    Name = "Марк",
                    LastName = "Сергеевич",
                    BirthDate = DateTime.Parse("1988-8-9"),
                    Level = "Средний",
                    Hobby = "Техника, машины",
                },
                new Student
                {
                    Surname = "Жукова",
                    Name = "Арина",
                    LastName = "Степановна",
                    BirthDate = DateTime.Parse("2011-8-16"),
                    Level = "Начальный",
                    Hobby = "Кино, сериалы",
                }
            };

            context.Students.AddRange(students);
            context.SaveChanges();

            var StudentCourse = new StudentCourse[]
            {
                new StudentCourse
                {
                    CourseID = 1,
                    StudentID = 1
                },
                new StudentCourse
                {
                    CourseID = 1,
                    StudentID = 2
                },
                new StudentCourse
                {
                    CourseID = 1,
                    StudentID = 3
                },
                new StudentCourse
                {
                    CourseID = 1,
                    StudentID = 4
                },
                new StudentCourse
                {
                    CourseID = 1,
                    StudentID = 5
                },
                new StudentCourse
                {
                    CourseID = 1,
                    StudentID = 7
                },
                new StudentCourse
                {
                    CourseID = 1,
                    StudentID = 14
                },
                new StudentCourse
                {
                    CourseID = 2,
                    StudentID = 6
                },
                new StudentCourse
                {
                    CourseID = 2,
                    StudentID = 7
                },
                new StudentCourse
                {
                    CourseID = 2,
                    StudentID = 8
                },
                new StudentCourse
                {
                    CourseID = 2,
                    StudentID = 9
                },
                new StudentCourse
                {
                    CourseID = 2,
                    StudentID = 10
                },
                new StudentCourse
                {
                    CourseID = 2,
                    StudentID = 4
                },
                new StudentCourse
                {
                    CourseID = 2,
                    StudentID = 15
                },
                new StudentCourse
                {
                    CourseID = 3,
                    StudentID = 11
                },
                new StudentCourse
                {
                    CourseID = 3,
                    StudentID = 12
                },
                new StudentCourse
                {
                    CourseID = 3,
                    StudentID = 13
                },
                new StudentCourse
                {
                    CourseID = 3,
                    StudentID = 14
                },
                new StudentCourse
                {
                    CourseID = 3,
                    StudentID = 15
                },
                new StudentCourse
                {
                    CourseID = 3,
                    StudentID = 16
                },
                new StudentCourse
                {
                    CourseID = 3,
                    StudentID = 1
                },
                new StudentCourse
                {
                    CourseID = 3,
                    StudentID = 18
                },
                new StudentCourse
                {
                    CourseID = 4,
                    StudentID = 17
                },
                new StudentCourse
                {
                    CourseID = 4,
                    StudentID = 18
                },
                new StudentCourse
                {
                    CourseID = 4,
                    StudentID = 19
                },
                new StudentCourse
                {
                    CourseID = 4,
                    StudentID = 20
                },
                new StudentCourse
                {
                    CourseID = 4,
                    StudentID = 21
                },
                new StudentCourse
                {
                    CourseID = 4,
                    StudentID = 8
                },
                new StudentCourse
                {
                    CourseID = 4,
                    StudentID = 22
                },
                new StudentCourse
                {
                    CourseID = 4,
                    StudentID = 4
                }
            };

            context.StudentCourse.AddRange(StudentCourse);
            context.SaveChanges();

            var teachers = new Teacher[]
            {
                new Teacher
                {
                    Surname = "Сафонова",
                    Name = "Алёна",
                    LastName = "Владиславовна",
                    DateStartTeaching = DateTime.Parse("2015-7-15"),
                    Education = "Высшее образование",
                },
                new Teacher
                {
                    Surname = "Сорокин",
                    Name = "Вадим",
                    LastName = "Миронович",
                    DateStartTeaching = DateTime.Parse("2018-3-11"),
                    Education = "Лингвист",
                },
                new Teacher
                {
                    Surname = "Шмелева",
                    Name = "Вера",
                    LastName = "Ярославовна",
                    DateStartTeaching = DateTime.Parse("2020-3-10"),
                    Education = "Переводчик",
                },
                new Teacher
                {
                    Surname = "Юдина",
                    Name = "Валерия",
                    LastName = "Арсеньевна",
                    DateStartTeaching = DateTime.Parse("2017-2-11"),
                    Education = "Зарубежное образование",
                },
                new Teacher
                {
                    Surname = "Трофимов",
                    Name = "Артём",
                    LastName = "Леонидович",
                    DateStartTeaching = DateTime.Parse("2019-3-11"),
                    Education = "Преподаватель, переводчик",
                },
                new Teacher
                {
                    Surname = "Соколова",
                    Name = "София",
                    LastName = "Ивановна",
                    DateStartTeaching = DateTime.Parse("2021-3-11"),
                    Education = "Высшее образование, Лингвист",
                },
                new Teacher
                {
                    Surname = "Степанова",
                    Name = "Мария",
                    LastName = "Львовна",
                    DateStartTeaching = DateTime.Parse("2015-3-11"),
                    Education = "Историк, переводчик",
                },
                new Teacher
                {
                    Surname = "Носов",
                    Name = "Роман",
                    LastName = "Артёмович",
                    DateStartTeaching = DateTime.Parse("2016-3-11"),
                    Education = "Филолог, лингвист",
                }
            };

            context.Teachers.AddRange(teachers);
            context.SaveChanges();

            var TeacherCourse = new TeacherCourse[]
            {
                new TeacherCourse
                {
                    TeacherID = 1,
                    CourseID = 1
                },
                new TeacherCourse
                {
                    TeacherID = 1,
                    CourseID = 2
                },
                new TeacherCourse
                {
                    TeacherID = 2,
                    CourseID = 3
                },
                new TeacherCourse
                {
                    TeacherID = 3,
                    CourseID = 4
                },
                new TeacherCourse
                {
                    TeacherID = 2,
                    CourseID = 1
                },
                new TeacherCourse
                {
                    TeacherID = 3,
                    CourseID = 2
                },
                new TeacherCourse
                {
                    TeacherID = 4,
                    CourseID = 3
                },
                new TeacherCourse
                {
                    TeacherID = 4,
                    CourseID = 1
                },
            };

            context.TeacherCourse.AddRange(TeacherCourse);
            context.SaveChanges();

            var reviews = new Review[]
            {
                new Review
                {
                    Author = "Жукова Арина",
                    Text = "Очень хороший курс! Всем рекомендую!",
                    Evaluation = 10,
                    CourseID = 4
                },
                new Review
                {
                    Author = "Мастер слова",
                    Text = "Неплохо объясняют, но не хватает примеров. " +
                    "Курс отличный, но добавьте, пожалуйста, примеры, где может пригодиться. Спасибо!",
                    Evaluation = 7,
                    CourseID = 3
                },
                new Review
                {
                    Author = "Матвей Олегович",
                    Text = "Мне понравился. Хороший коллектив, отзывчивые преподаватели, курс интересный)",
                    Evaluation = 10,
                    CourseID = 1
                },
                new Review
                {
                    Author = "Инкогнито",
                    Text = "",
                    Evaluation = 4,
                    CourseID = 4
                },
                new Review
                {
                    Author = "Белова София",
                    Text = "Все понятно объясняют! Интересно преподают!",
                    Evaluation = 10,
                    CourseID = 2
                },
                new Review
                {
                    Author = "Винокуров",
                    Text = "Неплохо, но есть над чем поработать",
                    Evaluation = 6,
                    CourseID = 3
                },
                new Review
                {
                    Author = "Полина",
                    Text = "Все супер! Спасибо большое! Теперь буду слушать корейскую музыку!!!",
                    Evaluation = 10,
                    CourseID = 2
                },
                new Review
                {
                    Author = "Власова Мария",
                    Text = "Не знаю, вроде неплохой",
                    Evaluation = 5,
                    CourseID = 1
                },
                new Review
                {
                    Author = "Беляев Артём Маркович",
                    Text = "",
                    Evaluation = 9,
                    CourseID = 4
                },
                new Review
                {
                    Author = "Василиса Прекрасная))",
                    Text = "",
                    Evaluation = 10,
                    CourseID = 2
                }
            };

            context.Reviews.AddRange(reviews);
            context.SaveChanges();
        }
    }
}
