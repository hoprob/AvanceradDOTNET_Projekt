using AvanceradDOTNET_Projekt.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Projekt.API.Services
{
    //TODO Getall employees
    public class EmployeeRepository : IRestAPI<Employee>
    {
        public Task<Employee> AddAsync(Employee item)
        {
            throw new System.NotImplementedException();
        }

        public Task<Employee> DeleteAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Employee>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<Employee> GetSingleAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Employee> UpdateAsync(Employee item)
        {
            throw new System.NotImplementedException();
        }
    }
}
