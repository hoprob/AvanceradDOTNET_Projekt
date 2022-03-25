using AvanceradDOTNET_Projekt.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Projekt.API.Model
{
    public class ProjectDbContext : DbContext
    {
        public ProjectDbContext(DbContextOptions<ProjectDbContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<TimeReport> TimeReports { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                Id = 1,
                FirstName = "Karl",
                LastName = "Karlsson",
                Address = "Såggatan 4, 43295 Varberg",
                Phone = "0796524936"
            });
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                Id = 2,
                FirstName = "Tommy",
                LastName = "Nilsson",
                Address = "Sångvägen 8, 13659 Skellefteå",
                Phone = "0794632846"
            });
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                Id = 3,
                FirstName = "Jonna",
                LastName = "Mikaelsson",
                Address = "Odengatan 46, 76519 Stockholm",
                Phone = "0736428585"
            });
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                Id = 4,
                FirstName = "Mats",
                LastName = "Fransson",
                Address = "Tomtevägen 50B, 26489 Malmö",
                Phone = "0796524936"
            });
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                Id = 5,
                FirstName = "Dagny",
                LastName = "Svantesson",
                Address = "Magistervägen 2, 43294 Varberg",
                Phone = "0754256925"
            });
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                Id = 6,
                FirstName = "Jens",
                LastName = "Haraldsson",
                Address = "Plåtgatan 9, 52648 Falkenberg",
                Phone = "0706175289"
            });
            modelBuilder.Entity<Project>().HasData(new Project
            {
                Id = 1,
                ProjectName = "Kvarteret Nystaden",
                ProjectNumber = "55-2636"
            });
            modelBuilder.Entity<Project>().HasData(new Project
            {
                Id = 2,
                ProjectName = "Ombyggnad Kollebrien",
                ProjectNumber = "54-9462"
            });
            modelBuilder.Entity<Project>().HasData(new Project
            {
                Id = 3,
                ProjectName = "Kvarteret Yxan",
                ProjectNumber = "55-2856"
            });
            modelBuilder.Entity<Project>().HasData(new Project
            {
                Id = 4,
                ProjectName = "Ombyggnad Kommunhus C",
                ProjectNumber = "54-5454"
            });
            modelBuilder.Entity<Project>().HasData(new Project
            {
                Id = 5,
                ProjectName = "Renovering Villa Markström",
                ProjectNumber = "53-5521"
            });
            modelBuilder.Entity<TimeReport>().HasData(new TimeReport
            {
                Id = 1,
                Date = DateTime.Parse("2022-03-24"),
                HoursWorked = 8,
                EmployeeId = 1,
                ProjectId = 1
            });
            modelBuilder.Entity<TimeReport>().HasData(new TimeReport
            {
                Id = 2,
                Date = DateTime.Parse("2022-03-24"),
                HoursWorked = 8,
                EmployeeId = 2,
                ProjectId = 1
            });
            modelBuilder.Entity<TimeReport>().HasData(new TimeReport
            {
                Id = 3,
                Date = DateTime.Parse("2022-02-24"),
                HoursWorked = 8,
                EmployeeId = 2,
                ProjectId = 1
            });
            modelBuilder.Entity<TimeReport>().HasData(new TimeReport
            {
                Id = 4,
                Date = DateTime.Parse("2022-02-24"),
                HoursWorked = 8,
                EmployeeId = 1,
                ProjectId = 1
            });
            modelBuilder.Entity<TimeReport>().HasData(new TimeReport
            {
                Id = 5,
                Date = DateTime.Parse("2022-01-24"),
                HoursWorked = 7,
                EmployeeId = 3,
                ProjectId = 3
            });
            modelBuilder.Entity<TimeReport>().HasData(new TimeReport
            {
                Id = 6,
                Date = DateTime.Parse("2022-01-24"),
                HoursWorked = 1,
                EmployeeId = 3,
                ProjectId = 4
            });
            modelBuilder.Entity<TimeReport>().HasData(new TimeReport
            {
                Id = 7,
                Date = DateTime.Parse("2021-08-24"),
                HoursWorked = 8,
                EmployeeId = 5,
                ProjectId = 5
            });
            modelBuilder.Entity<TimeReport>().HasData(new TimeReport
            {
                Id = 8,
                Date = DateTime.Parse("2021-07-24"),
                HoursWorked = 8,
                EmployeeId = 5,
                ProjectId = 5
            });
            modelBuilder.Entity<TimeReport>().HasData(new TimeReport
            {
                Id = 9,
                Date = DateTime.Parse("2021-07-24"),
                HoursWorked = 8,
                EmployeeId = 4,
                ProjectId = 1
            });
            modelBuilder.Entity<TimeReport>().HasData(new TimeReport
            {
                Id = 10,
                Date = DateTime.Parse("2022-07-24"),
                HoursWorked = 8,
                EmployeeId = 3,
                ProjectId = 5
            });
        }
    }
}
