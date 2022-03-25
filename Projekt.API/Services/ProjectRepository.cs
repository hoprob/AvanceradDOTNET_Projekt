using AvanceradDOTNET_Projekt.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Projekt.API.Services
{
    public class ProjectRepository : IRestAPI<Project>
    {
        public Task<Project> AddAsync(Project item)
        {
            throw new System.NotImplementedException();
        }

        public Task<Project> DeleteAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Project>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<Project> GetSingleAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Project> UpdateAsync(Project item)
        {
            throw new System.NotImplementedException();
        }
    }
}
