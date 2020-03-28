using Project.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
namespace Project.Service.VehicleService
{
    public interface IVehicleServiceModel
    {
        Task<IEnumerable<VehicleModel>> FindAllAsync(string expression);
        Task<IEnumerable<VehicleModel>> OrderByAsync(Expression<Func<VehicleModel, object>> sort);
        Task<IEnumerable<VehicleModel>> GetAllAsync();
        Task<VehicleModel> GetByIdAsync(int id);
        Task InsertAsync(VehicleModel vehicleModel);
        Task UpdateAsync(VehicleModel vehicleModel);
        Task DeleteAsync(int id);
    }
}
