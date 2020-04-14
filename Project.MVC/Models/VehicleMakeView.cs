using Project.Service.ServiceModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project.MVC.Models
{
    public class VehicleMakeView : IBaseView
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Abrv { get; set; }
        public virtual IEnumerable<VehicleModelView> VehicleModels { get; set; }
    }
}

