using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReliableCarDealership.Data;
using ReliableCarDealership.Models;
using ReliableCarDealership.Services;

namespace ReliableCarDealership.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly AppDbContext appDbContext;
        private readonly IShoppingCartService shoppingCartService;
        private readonly UserManager<IdentityUser> _userManager;

        public ShoppingCartController(AppDbContext appDbContext, IShoppingCartService shoppingCartService, UserManager<IdentityUser> userManager)
        {
            this.appDbContext = appDbContext;
            this.shoppingCartService = shoppingCartService;
            this._userManager = userManager;
        }

        public IActionResult Cart()
        {
            //use the current user's ID to get the cart
            var currentuserid = _userManager.GetUserId(User);
            var cart = shoppingCartService.GetCartByUserId(currentuserid);
            return View(cart);
            //var cart = shoppingCartService.GetCartByUserId("3e7b7a13-866f-4056-84ca-a03788fad957");            
            //return View(cart);
        }

        public IActionResult AddtoCart(int partId)
        {
            var currentuserid = _userManager.GetUserId(User);
            shoppingCartService.AddToCart(partId);
            return RedirectToAction("Cart");
            //shoppingCartService.AddToCart(partId);

            //return RedirectToAction("Cart");
        }
    }
}
