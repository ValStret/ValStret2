using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ReliableCarDealership.Models.ViewModels;

namespace ReliableCarDealership.Models
{
    public class Car
    {
        public int CarId { get; set; }
        [Required]
        [MaxLength(20)]
        public string MakeModel { get; set; }
        [Required]
        public int Mileage { get; set; }
        [Required]
        [MaxLength(10)]
        public string Colour { get; set; }
        [Required]
        public int YearOfProduct { get; set; }
        [Required]
        public string Engine { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public string Description { get; set; }        
        public string CarImage { get; set; }
        public string DetailImage { get; set; }
        public List<Invoice> Invoices { get; set; }
        
        
        public Car (string makeModel, int mileage, string colour, int yearProduct, string engine, double price, string description, string carImage, string detailImage)
        {
            MakeModel = makeModel;
            Mileage = mileage;
            Colour = colour;
            YearOfProduct = yearProduct;
            Engine = engine;
            Price = price;
            Description = description;
            CarImage = carImage;
            DetailImage = detailImage;
        }

        public Car()
        {
            MakeModel = "";
            Mileage = 0;
            Colour = "";
            YearOfProduct = 0;
            Engine = "";
            Price = 0;
            Description = "";
            CarImage = "";
            DetailImage = "";
        }
    }
}    
