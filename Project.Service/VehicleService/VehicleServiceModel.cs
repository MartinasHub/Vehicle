using Project.Service.ServiceModels;
using System.Collections.Generic;
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

        public async Task<IEnumerable<VehicleModel>> GetAllAsync(string search, string sort, int? page)
        {
            return await _repository.GetAllAsync(search, sort, page);
        }

        public async Task<VehicleModel> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task InsertAsync(VehicleModel vehicleModel)
        {
            await _repository.InsertAsync(vehicleModel);
        }

        public async Task UpdateAsync(VehicleModel vehicleModel)
        {
            await _repository.UpdateAsync(vehicleModel);
        }
    }
}
