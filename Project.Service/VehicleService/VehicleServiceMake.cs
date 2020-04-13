using Project.Service.ServiceModels;
using System.Collections.Generic;
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

        public async Task<IEnumerable<VehicleMake>> GetAllAsync(string search, string sort, int? page)
        {
            return await _repository.GetAllAsync(search, sort, page);
        }

        public async Task<VehicleMake> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task InsertAsync(VehicleMake vehicleMake)
        {
            await _repository.InsertAsync(vehicleMake);
        }

        public async Task UpdateAsync(VehicleMake vehicleMake)
        {
            await _repository.UpdateAsync(vehicleMake);
        }
    }
}
