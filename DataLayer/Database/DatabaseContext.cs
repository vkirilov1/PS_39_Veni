using DataLayer.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welcome.Others;

namespace DataLayer.Database
{
    internal class DatabaseContext : DbContext
    {
        public DbSet<DatabaseUser> Users { get; set; }
        public DbSet<DBLogEntry> Logs { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string solutionFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string databaseFile = "Welcome.db";
            string databasePath = Path.Combine(solutionFolder, databaseFile);
            optionsBuilder.UseSqlite($"Data Source={databasePath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DatabaseUser>().Property(e => e.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<DBLogEntry>().Property(e => e.Id).ValueGeneratedOnAdd();

            var adminUser = new DatabaseUser()
            {
                Id = 1,
                Name = "John Doe",
                Password = "admin123",
                Role = UserRolesEnum.ADMIN,
                Expires = DateTime.Now.AddYears(10)
            };

            var professorUser = new DatabaseUser()
            {
                Id = 2,
                Name = "Ivan Ivanov",
                Password = "professor123",
                Role = UserRolesEnum.PROFESSOR,
                Expires = DateTime.Now.AddYears(6)
            };

            var studentUser = new DatabaseUser()
            {
                Id = 3,
                Name = "Georgi Georgiev",
                Password = "student123",
                Role = UserRolesEnum.STUDENT,
                Expires = DateTime.Now.AddYears(4)
            };

            modelBuilder.Entity<DatabaseUser>()
                .HasData(adminUser, professorUser, studentUser);
        }
    }
}
