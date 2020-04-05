using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Service.ServiceModels
{
    public class VehicleModel : IBaseDomain
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
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