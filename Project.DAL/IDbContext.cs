using Project.Model.Common;
using System.Data.Entity;

namespace Project.DAL
{
    public interface IDbContext
    {
        IDbSet<TEntity> Set<TEntity>() where TEntity : class, IBaseDomain;
        int SaveChanges();
    }
}
