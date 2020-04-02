using PagedList;
using Project.Service.ServiceModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.Service.VehicleService
{
    public interface IVehicleServiceMake
    {
        Task <IEnumerable<VehicleMake>> FindAllAsync(string expression);
        Task<IEnumerable<VehicleMake>> OrderByAsync(string sort);
        Task<IEnumerable<VehicleMake>> GetAllAsync();
        Task<VehicleMake> GetByIdAsync(int id);
        Task InsertAsync(VehicleMake vehicleMake);
        Task UpdateAsync(VehicleMake vehicleMake);
        Task DeleteAsync(int id);
        Task<IEnumerable<VehicleMake>> PaginationAsync(int? page);
    }
}
