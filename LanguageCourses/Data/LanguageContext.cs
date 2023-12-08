using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LanguageCourses.Models;

namespace LanguageCourses.Data
{
    public class LanguageContext : DbContext
    {
        public LanguageContext (DbContextOptions<LanguageContext> options)
            : base(options)
        {
        }

        public DbSet<Language> Languages { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<StudentCourse> StudentCourse { get; set; }
        public DbSet<TeacherCourse> TeacherCourse { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Language>().ToTable("Language");
            modelBuilder.Entity<Course>().ToTable("Course");
            modelBuilder.Entity<Student>().ToTable("Student");
            modelBuilder.Entity<Teacher>().ToTable("Teacher");
            modelBuilder.Entity<Review>().ToTable("Review");
            modelBuilder.Entity<StudentCourse>().ToTable("StudentCourse");
            modelBuilder.Entity<TeacherCourse>().ToTable("TeacherCourse");
        }
    }
}
