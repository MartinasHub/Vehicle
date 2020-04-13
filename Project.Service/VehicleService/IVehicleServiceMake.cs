using Project.Service.ServiceModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.Service.VehicleService
{
    public interface IVehicleServiceMake
    {
        Task<IEnumerable<VehicleMake>> GetAllAsync(string search, string sort, int? page);
        Task<VehicleMake> GetByIdAsync(int id);
        Task InsertAsync(VehicleMake vehicleMake);
        Task UpdateAsync(VehicleMake vehicleMake);
        Task DeleteAsync(int id);
    }
}
