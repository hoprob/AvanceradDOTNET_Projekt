using AvanceradDOTNET_Projekt.Models;
using Microsoft.EntityFrameworkCore;

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
    }
}
