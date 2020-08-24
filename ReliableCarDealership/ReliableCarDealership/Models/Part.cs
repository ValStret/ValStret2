using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ReliableCarDealership.Models
{
    public class Part
    {
        [Key]
        public int PartId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public string PartMakeModel { get; set; }
        [Required]
        public int PartVehicleYear { get; set; }
        [Required]
        public double PartPrice { get; set; }
        [Required]
        [MaxLength(200)]
        public string Description { get; set; }
        public string PartImage { get; set; }

    }
}
