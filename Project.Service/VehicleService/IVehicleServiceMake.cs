using Project.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.Service.VehicleService
{
    public interface IVehicleServiceMake
    {
        Task <IEnumerable<VehicleMake>> FindAllAsync(Expression<Func<VehicleMake, bool>> expression);
        Task<IEnumerable<VehicleMake>> OrderByAsync(Expression<Func<VehicleMake, object>> sort);
        Task<IEnumerable<VehicleMake>> GetAllAsync();
        Task<VehicleMake> GetByIdAsync(int id);
        Task InsertAsync(VehicleMake vehicleMake);
        Task UpdateAsync(VehicleMake vehicleMake);
        Task DeleteAsync(int id);
    }
}
