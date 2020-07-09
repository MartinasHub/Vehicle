using Project.Model.Common;
using System;
using System.Threading.Tasks;

namespace Project.Repository.Common
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> CommitAsync();

        Task<int> InsertAsync<T>(T entity) where T : class, IBaseDomain;
        Task<int> UpdateAsync<T>(T entity) where T : class, IBaseDomain;
        Task<int> DeleteAsync<T>(T entity) where T : class, IBaseDomain;
        Task<int> DeleteAsync<T>(Guid id) where T : class, IBaseDomain;
    }
}
