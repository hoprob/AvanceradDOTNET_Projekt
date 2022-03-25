using AvanceradDOTNET_Projekt.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Projekt.API.Services
{
    public class TimeReportRepository : IRestAPI<TimeReport>
    {
        public Task<TimeReport> AddAsync(TimeReport item)
        {
            throw new System.NotImplementedException();
        }

        public Task<TimeReport> DeleteAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<TimeReport>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<TimeReport> GetSingleAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<TimeReport> UpdateAsync(TimeReport item)
        {
            throw new System.NotImplementedException();
        }
    }
}
