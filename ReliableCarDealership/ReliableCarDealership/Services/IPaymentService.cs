using ReliableCarDealership.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReliableCarDealership.Services
{
    public interface IPaymentService
    {
        public Payment SavePayment(Payment payment);
    }
}
