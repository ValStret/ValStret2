using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReliableCarDealership.Models
{
    public class Invoice
    {
        public int InvoiceId { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }
        public DateTime InvoiceDate { get; set; }
        public double InvoiceSum { get; set; }        
    }
}
