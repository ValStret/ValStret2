using ReliableCarDealership.Data;
using ReliableCarDealership.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReliableCarDealership.Services
{
    public class OrderService:IOrderService
    {
        private readonly AppDbContext DbContext;

        public OrderService(AppDbContext dbContext)
        {
            this.DbContext = dbContext;
        }

        public Order SaveOrder(Order order)
        {
            DbContext.Add(order);
            DbContext.SaveChanges();
            return order;
        }

        public OrderItem SaveOrderItem(OrderItem orderItem)
        {
            DbContext.Add(orderItem);
            DbContext.SaveChanges();
            return orderItem;
        }
    }
}
