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
    public class VehicleServiceModel : IVehicleServiceModel
    {
        private IRepository<VehicleModel> _repository;

        public VehicleServiceModel(IRepository<VehicleModel> repository)
        {
            _repository = repository;
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<VehicleModel>> FindAllAsync(string expression)
        {
            return await _repository.FindAllAsync(expression);
        }

        public async Task<IEnumerable<VehicleModel>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<VehicleModel> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task InsertAsync(VehicleModel vehicleModel)
        {
            await _repository.InsertAsync(vehicleModel);
        }

        public async Task<IEnumerable<VehicleModel>> OrderByAsync(string sort)
        {
            return await _repository.OrderByAsync(sort);
        }

        public async Task UpdateAsync(VehicleModel vehicleModel)
        {
            await _repository.UpdateAsync(vehicleModel);
        }
    }
}
