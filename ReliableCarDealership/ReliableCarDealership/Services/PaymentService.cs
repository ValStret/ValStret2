using ReliableCarDealership.Data;
using ReliableCarDealership.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReliableCarDealership.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly AppDbContext DbContext;

        public PaymentService(AppDbContext dbContext)
        {
            this.DbContext = dbContext;
        }
        public Payment SavePayment(Payment payment)
        {
            DbContext.Add(payment);
            DbContext.SaveChanges();
            return payment;
        }
    }
}
