using PagedList;
using Project.Service.ServiceModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.Service.VehicleService
{
    public interface IRepository<T> where T : BaseDomain
    {
        Task <IEnumerable<T>> FindAllAsync(string expression);
        Task <IEnumerable<T>> OrderByAsync(string sort);
        Task <IEnumerable<T>> GetAllAsync();
        Task <T> GetByIdAsync(int id);
        Task InsertAsync(T domain);
        Task UpdateAsync(T domain);
        Task DeleteAsync(int id);
        Task <IEnumerable<T>> PaginationAsync(int? page);
    }
}
