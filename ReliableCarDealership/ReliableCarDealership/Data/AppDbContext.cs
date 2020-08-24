using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ReliableCarDealership.Models;


namespace ReliableCarDealership.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<ReliableCarDealership.Models.Customer> Customer { get; set; }
        public DbSet<ReliableCarDealership.Models.Car> Car { get; set; }
        public DbSet<ReliableCarDealership.Models.Invoice> Invoice { get; set; }
        public DbSet<ReliableCarDealership.Models.Part> Part { get; set; }
        public DbSet<ReliableCarDealership.Models.Cart> Carts { get; set; }
        public DbSet<ReliableCarDealership.Models.ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<ReliableCarDealership.Models.Order> Orders { get; set; }
        public DbSet<ReliableCarDealership.Models.OrderItem> OrderItems { get; set; }
        public DbSet<ReliableCarDealership.Models.Payment> Payments { get; set; }
        public DbSet<ReliableCarDealership.Models.TestDrive> TestDrives { get; set; }
        public DbSet<ReliableCarDealership.Models.TestDriveCar> TestDriveCars { get; set; }


    }
}
