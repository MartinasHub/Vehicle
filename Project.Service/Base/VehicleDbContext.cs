using Project.Service.ServiceModels;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Reflection;

namespace Project.Service.Base
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

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : BaseDomain
        {
            return base.Set<TEntity>();
        }

        public DbSet<VehicleModel> VehicleModels { get; set; }

        public DbSet<VehicleMake> VehicleMakes { get; set; }
    }
}
