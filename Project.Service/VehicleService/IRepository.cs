using PagedList;
using Project.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.Service.VehicleService
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task <IEnumerable<T>> FindAllAsync(string expression);
        Task <IEnumerable<T>> OrderByAsync(Expression<Func<T, object>> sort);
        Task <IEnumerable<T>> GetAllAsync();
        Task <T> GetByIdAsync(int id);
        Task InsertAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
    }
}
