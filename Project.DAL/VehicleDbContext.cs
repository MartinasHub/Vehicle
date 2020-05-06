using Project.Model;
using Project.Model.Common;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Project.DAL
{
    public class VehicleDbContext : DbContext, IDbContext
    {
        public VehicleDbContext()
            : base("name=VehicleDBContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class, IBaseDomain
        {
            return base.Set<TEntity>();
        }

        public DbSet<VehicleModel> VehicleModels { get; set; }
        public DbSet<VehicleMake> VehicleMakes { get; set; }
    }
}
