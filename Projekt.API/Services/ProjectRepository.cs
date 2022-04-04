using AvanceradDOTNET_Projekt.Models;
using Microsoft.EntityFrameworkCore;
using Projekt.API.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt.API.Services
{
    public class ProjectRepository : IProject
    {
        ProjectDbContext _context;
        public ProjectRepository(ProjectDbContext context)
        {
            _context = context;
        }
        public async Task<Project> AddAsync(Project item)
        {
            var result = await _context.Projects.AddAsync(item);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Project> DeleteAsync(int id)
        {
            var toDelete = await _context.Projects.FirstOrDefaultAsync(prop =>
            prop.Id == id);
            if(toDelete != null)
            {
                var result = _context.Projects.Remove(toDelete);
                await _context.SaveChangesAsync();
                return result.Entity;
            }
            return null;
        }

        public Task<IEnumerable<Project>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<Employee>> GetEmployeesInProjectAsync(int id)
        {
            var result = await  (_context.Employees.SelectMany(emp =>
            emp.TimeReports, (emp, time) => new { emp, time }).Where(p =>
            p.time.ProjectId == id).Select(e => e.emp)).Distinct().ToListAsync();
            return result;
        }

        public async Task<Project> GetSingleAsync(int id)
        {
            return await _context.Projects.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Project> UpdateAsync(Project item)
        {
            var toUpdate = await _context.Projects.FirstOrDefaultAsync(p =>
            p.Id == item.Id);
            if(toUpdate != null)
            {
                toUpdate.ProjectName = item.ProjectName;
                toUpdate.ProjectNumber = item.ProjectNumber;
                await _context.SaveChangesAsync();
                return toUpdate;
            }
            return null;
        }
    }
}
