using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ReliableCarDealership.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }        
        [Required]
        public string Address { get; set; }
        [Required]
        public int PhoneNumber { get; set; }
        [Required]
        public string Email { get; set; }
        public List<Invoice> Invoices { get; set; }

        public Customer(string name, string address, int phoneNumber, string email)
        {
            Name = name;
            Address = address;
            PhoneNumber = phoneNumber;
            Email = email;
        }

        public Customer()
        {
            Name = "";
            Address = "";
            PhoneNumber = 0;
            Email = "";
        }

    }    
}