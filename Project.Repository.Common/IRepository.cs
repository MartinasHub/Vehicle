using Project.Model.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.Repository.Common
{
    public interface IRepository<T> where T : IBaseDomain
    {
        Task<IEnumerable<T>> GetAllAsync(string search, string sortOrder, int? page);
        Task<T> GetByIdAsync(int id);
        Task InsertAsync(T domain);
        Task UpdateAsync(T domain);
        Task DeleteAsync(int id);
    }
}
