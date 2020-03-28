using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project.MVC.Models
{
    public class VehicleMake : BaseEntity
    {
        public virtual ICollection<VehicleModel> VehicleModels { get; set; }
    }
}