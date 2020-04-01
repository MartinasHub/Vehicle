using Project.Service.ServiceModels;

namespace Project.MVC.Models
{
    public class VehicleModelView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }

        public int MakeId { get; set; }

        public virtual VehicleMakeView VehicleMakes { get; set; }
    }
}