using AvanceradDOTNET_Projekt.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Projekt.API.Services
{
    public interface IProject : IRestAPI<Project>
    {
        public Task<IEnumerable<Employee>> GetEmployeesInProjectAsync(int id);
    }
}
