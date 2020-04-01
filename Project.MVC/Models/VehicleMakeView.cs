using Project.Service.ServiceModels;
using System.Collections.Generic;

namespace Project.MVC.Models
{
    public class VehicleMakeView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }

        public virtual ICollection<VehicleModelView> VehicleModels { get; set; }
    }
}