using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ReliableCarDealership.Models
{
    public class OrderItem
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public int ParttId { get; set; }
        public Part OrderItemPart { get; set; }
        [Required]
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
