using System.ComponentModel.DataAnnotations;

namespace Project.MVC.Models
{
    public class VehicleModelView : IBaseView
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Abrv { get; set; }
        [Display(Name = "Vehicle")]
        public int MakeId { get; set; }

        public virtual VehicleMakeView VehicleMakes { get; set; }
    }
}