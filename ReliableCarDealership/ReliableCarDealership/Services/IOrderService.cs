using ReliableCarDealership.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReliableCarDealership.Services
{
    public interface IOrderService
    {
        public Order SaveOrder(Order order);
        public OrderItem SaveOrderItem(OrderItem orderItem);
    }
}
