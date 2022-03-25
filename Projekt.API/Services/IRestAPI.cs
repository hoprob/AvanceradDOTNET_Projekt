using System.Collections.Generic;
using System.Threading.Tasks;

namespace Projekt.API.Services
{
    public interface IRestAPI<T>
    {
        public Task<IEnumerable<T>> GetAllAsync();
        public Task<T> GetSingleAsync(int id);
        public Task<T> AddAsync(T item);
        public Task<T> UpdateAsync(T item);
        public Task<T> DeleteAsync(int id);
    }
}
