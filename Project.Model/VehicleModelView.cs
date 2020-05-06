using Project.Model.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Model
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
