using System.Collections.Generic;

namespace Project.Service.ServiceModels
{
    public class VehicleMake : BaseDomain
    {
        public virtual ICollection<VehicleModel> VehicleModels { get; set; }
    }
}