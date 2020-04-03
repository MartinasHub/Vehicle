using Project.Service.ServiceModels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project.MVC.Models
{
    public class VehicleMakeView : BaseView
    {
        public virtual IEnumerable<VehicleModelView> VehicleModels { get; set; }
    }
}