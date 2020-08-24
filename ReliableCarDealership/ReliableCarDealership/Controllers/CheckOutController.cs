using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ReliableCarDealership.Models;
using ReliableCarDealership.Services;

namespace ReliableCarDealership.Controllers
{
    public class CheckOutController : Controller
    {
        private readonly IShoppingCartService ShoppingCartService;
        private readonly IOrderService OrderService;
        private readonly IPaymentService PaymentService;

        public CheckOutController(IShoppingCartService shoppingCartService, IOrderService orderService, IPaymentService paymentService)
        
        {
            this.ShoppingCartService = shoppingCartService;
            this.OrderService = orderService;
            this.PaymentService = paymentService;
        }
        public IActionResult Checkout()
        {            
            return View();
        }

        [HttpPost]
        public IActionResult CheckOut(Payment payment)
        {
            //load cart
            var cart = ShoppingCartService.GetCartByUserId("3e7b7a13-866f-4056-84ca-a03788fad957");
            if (cart != null)
            {
                //Validate payment
                //Create Payment Record in DB
                var processedPayment = PaymentService.SavePayment(payment);

                //Save order in DB
                var order = new Order();
                order.PaymentId = processedPayment.Id;
                order.UserId = "3e7b7a13-866f-4056-84ca-a03788fad957";
                order = OrderService.SaveOrder(order);

                //save OrderItems
                foreach (var item in cart.ItemsList)
                {
                    var orderItem = new OrderItem();
                    orderItem.OrderId = order.Id;
                    orderItem.ParttId = item.PartId;
                    orderItem.Quantity = item.Quantity;

                    OrderService.SaveOrderItem(orderItem);
                }


                return RedirectToAction("OrderSummary", new { OrderId=order.Id});
            }
            else
                return RedirectToAction("Index", "Home");
        }
    }
}
