using AvanceradDOTNET_Projekt.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Projekt.API.Services
{
    public interface IEmployee :IRestAPI<Employee>
    {
        public Task<double> HoursWorkedByWeekAsync(int id, int week);
        public Task<IEnumerable<TimeReport>> GetTimeReportsByEmployeeAsync(int id);
    }
}
