using Project.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.Service.Common
{
    public interface IVehicleServiceModel
    {
        Task<IEnumerable<VehicleModel>> GetAllAsync(string search, string sortOrder, int? page);
        Task<VehicleModel> GetByIdAsync(int id);
        Task InsertAsync(VehicleModel vehicleModel);
        Task UpdateAsync(VehicleModel vehicleModel);
        Task DeleteAsync(int id);
    }
}
