using AvanceradDOTNET_Projekt.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Projekt.API.Services
{
    public interface IEmployee :IRestAPI<Employee>
    {
        public Task<double> HoursWorkedByWeekAsync(int id, int year, int week);
        public Task<Employee> GetTimeReportsByEmployeeAsync(int id);
    }
}
