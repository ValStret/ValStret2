using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace ReliableCarDealership.Models
{
    public class Order
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        public int PaymentId { get; set; }
        [Required]
        public int BillingAddress { get; set; }

        public Payment OrderPayment { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }
}