using AvanceradDOTNET_Projekt.Models;
using Microsoft.EntityFrameworkCore;
using Projekt.API.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt.API.Services
{
    public class EmployeeRepository : IEmployee
    {
        ProjectDbContext _context;
        public EmployeeRepository(ProjectDbContext context)
        {
            _context = context;
        }

        public async Task<Employee> AddAsync(Employee item)
        {
            var result = await _context.AddAsync(item);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Employee> DeleteAsync(int id)
        {
            var toDelete = await _context.Employees.FirstOrDefaultAsync(e => e.Id == id);
            if(toDelete != null)
            {
                var result = _context.Employees.Remove(toDelete);
                await _context.SaveChangesAsync();
                return result.Entity;
            }
            return null;
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee> GetSingleAsync(int id)
        {
            return await _context.Employees.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<IEnumerable<TimeReport>> GetTimeReportsByEmployeeAsync(int id)
        {
            var timeReports = await _context.TimeReports.Where(e => e.Id == id).ToListAsync();
            return timeReports;
        }

        public async Task<double> HoursWorkedByWeekAsync(int id, int week)
        {
            double hours = 0;
            await _context.TimeReports.Where(x => x.EmployeeId == id && x.Week == week).ForEachAsync((x) => { hours += x.HoursWorked; });
            return hours;
        }

        public async Task<Employee> UpdateAsync(Employee item)
        {
            var toUpdate = await _context.Employees.FirstOrDefaultAsync(e => e.Id == item.Id);
            if(toUpdate != null)
            {
                toUpdate.FirstName = item.FirstName;
                toUpdate.LastName = item.LastName;
                toUpdate.Address = item.Address;
                toUpdate.Phone = item.Phone;
                await _context.SaveChangesAsync();
                return toUpdate;
            }
            return null;
        }
    }
}
