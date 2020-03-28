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
        [Display(Name = "Vehicle")]
        public int MakeId { get; set; }
        [ForeignKey("MakeId")]
        public virtual VehicleMake VehicleMakes { get; set; }
    }
}