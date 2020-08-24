using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;



namespace ReliableCarDealership.Models
{
    public class TestDriveCar
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int CarId { get; set; }
        public Car Car { get; set; }
        [Required]
        public int TestDriveId { get; set; }
        public TestDrive TestDrive { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime TestDriveDate { get; set; }
    }
}
