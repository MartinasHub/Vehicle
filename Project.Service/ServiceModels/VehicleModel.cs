using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Project.MVC.Models
{
    public class VehicleModel : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Abrv { get; set; }

        [Display(Name = "Vehicle")]
        public int MakeId { get; set; }
        [ForeignKey("MakeId")]
        public virtual VehicleMake VehicleMakes { get; set; }
    }
}