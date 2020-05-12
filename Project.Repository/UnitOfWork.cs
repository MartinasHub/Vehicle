using Project.DAL;
using Project.Model;
using System;

namespace Project.Repository
{
    public class UnitOfWork : IDisposable
    {
        private readonly VehicleDbContext _context = new VehicleDbContext();
        private Repository<VehicleMake> vehicleMakeRepository;
        private Repository<VehicleModel> vehicleModelRepository;

        public Repository<VehicleMake> VehicleMakeRepository
        {
            get
            {
                if(this.vehicleMakeRepository == null)
                {
                    this.vehicleMakeRepository = new Repository<VehicleMake>(_context);
                }
                return vehicleMakeRepository;
            }
        }

        public Repository<VehicleModel> VehicleModelRepository
        {
            get
            {
                if (this.vehicleModelRepository == null)
                {
                    this.vehicleModelRepository = new Repository<VehicleModel>(_context);
                }
                return vehicleModelRepository;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
