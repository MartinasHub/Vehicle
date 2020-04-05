using Project.Service.ServiceModels;
using System.Data.Entity;

namespace Project.Service.Base
{
    public interface IDbContext
    {
        IDbSet<TEntity> Set<TEntity>() where TEntity : class, IBaseDomain;
        int SaveChanges();
    }
}
