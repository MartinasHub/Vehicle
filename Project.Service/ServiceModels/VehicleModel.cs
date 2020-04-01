using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Service.ServiceModels
{
    public class VehicleModel : BaseDomain
    {
        [Display(Name = "Vehicle")]
        public int MakeId { get; set; }
        [ForeignKey("MakeId")]
        public virtual VehicleMake VehicleMakes { get; set; }
    }
}