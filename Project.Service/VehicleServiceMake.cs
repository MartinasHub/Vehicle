using Project.Model;
using Project.Repository.Common;
using Project.Service.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.Service
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

        public async Task<IEnumerable<VehicleMake>> GetAllAsync(string search, string sortOrder, int? page)
        {
            return await _repository.GetAllAsync(search, sortOrder, page);
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
