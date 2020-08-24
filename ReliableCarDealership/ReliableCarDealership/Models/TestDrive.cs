using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ReliableCarDealership.Models
{
    public class TestDrive
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string UserId { get; set; }
        
        public DateTime BookedOn { get; set; }

        public List<TestDriveCar> TestDriveCarsList { get; set; }

    }
}
