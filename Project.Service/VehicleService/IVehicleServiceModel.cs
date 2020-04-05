using Project.Service.ServiceModels;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Project.Service.VehicleService
{
    public interface IVehicleServiceModel
    {
        Task<IEnumerable<VehicleModel>> FindAllAsync(string expression);
        Task<IEnumerable<VehicleModel>> OrderByAsync(string sort);
        Task<IEnumerable<VehicleModel>> GetAllAsync();
        Task<VehicleModel> GetByIdAsync(int id);
        Task InsertAsync(VehicleModel vehicleModel);
        Task UpdateAsync(VehicleModel vehicleModel);
        Task DeleteAsync(int id);
        Task<IEnumerable<VehicleModel>> PaginationAsync(int? page);
    }
}
