using Project.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Project.Service.VehicleService
{
    public class VehicleServiceMake : IVehicleServiceMake
    {
        private IRepository<VehicleMake> _repository;

        public VehicleServiceMake(IRepository<VehicleMake> repository)
        {
            _repository = repository;
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task <IEnumerable<VehicleMake>> FindAllAsync(string expression)
        {
            return await _repository.FindAllAsync(expression);
        }

        public async Task<IEnumerable<VehicleMake>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<VehicleMake> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task InsertAsync(VehicleMake vehicleMake)
        {
            await _repository.InsertAsync(vehicleMake);
        }

        public async Task<IEnumerable<VehicleMake>> OrderByAsync(Expression<Func<VehicleMake, object>> sort)
        {
            return await _repository.OrderByAsync(sort);
        }

        public async Task UpdateAsync(VehicleMake vehicleMake)
        {
            await _repository.UpdateAsync(vehicleMake);
        }
    }
}
