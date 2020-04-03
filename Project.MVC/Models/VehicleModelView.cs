using Project.Service.ServiceModels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project.MVC.Models
{
    public class VehicleModelView : BaseView
    {
        [Display(Name = "Vehicle")]
        public int MakeId { get; set; }

        public virtual VehicleMakeView VehicleMakes { get; set; }
    }
}