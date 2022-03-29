using AvanceradDOTNET_Projekt.Models;
using Microsoft.EntityFrameworkCore;
using Projekt.API.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Projekt.API.Services
{
    public class TimeReportRepository : IRestAPI<TimeReport>
    {
        ProjectDbContext _context;
        public TimeReportRepository(ProjectDbContext context)
        {
            _context = context;
        }
        public async Task<TimeReport> AddAsync(TimeReport item)
        {
            var result =  await _context.TimeReports.AddAsync(item);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<TimeReport> DeleteAsync(int id)
        {
            var toDelete = await _context.TimeReports.FirstOrDefaultAsync(t => t.Id == id);
            if(toDelete != null)
            {
                var result = _context.TimeReports.Remove(toDelete);
                await _context.SaveChangesAsync();
                return result.Entity;
            }
            return null;
        }

        public Task<IEnumerable<TimeReport>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public async Task<TimeReport> GetSingleAsync(int id)
        {
            return await _context.TimeReports.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<TimeReport> UpdateAsync(TimeReport item)
        {
            var toUpdate = await _context.TimeReports.FirstOrDefaultAsync(t => t.Id == item.Id);
            if(toUpdate != null)
            {
                toUpdate.Date = item.Date;
                toUpdate.HoursWorked = item.HoursWorked;
                toUpdate.EmployeeId = item.EmployeeId;
                toUpdate.ProjectId = item.ProjectId;
                await _context.SaveChangesAsync();
                return toUpdate;
            }
            return null;
        }
    }
}
