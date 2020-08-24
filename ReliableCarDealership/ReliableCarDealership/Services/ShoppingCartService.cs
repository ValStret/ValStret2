using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using ReliableCarDealership.Data;
using ReliableCarDealership.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ReliableCarDealership.Services
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly AppDbContext dbContext;
        private readonly UserManager<IdentityUser> _userManager;

        public ClaimsPrincipal User { get; private set; }

        public ShoppingCartService(AppDbContext dbContext, UserManager<IdentityUser> userManager)
        {
            this.dbContext = dbContext;
            this._userManager = userManager;
        }

        public Cart GetCartById(int Id)
        {
            var cart = dbContext.Carts
                .Include(s => s.ItemsList).ThenInclude(p => p.CartItemPart)
                .FirstOrDefault(m => m.Id == Id);
            return cart;
        }

        public Cart GetCartByUserId(string userId)
        {
            var cart = dbContext.Carts
                .Include(s => s.ItemsList).ThenInclude(p => p.CartItemPart)
                .FirstOrDefault(m => m.UserId == userId);
            return cart;
        }

        public Cart UpdateShoppingCartItem(int partId)
        {
            throw new NotImplementedException();
        }

        public ShoppingCartItem AddToCart(int partId)
        {
            //code to get the current userId
            var currentuserid = _userManager.GetUserId(User);
            var cart = GetCartByUserId(currentuserid);

            //var cart = GetCartByUserId("3e7b7a13-866f-4056-84ca-a03788fad957");
            if (cart == null)
            {            
                //create new cart for current user
                cart=CreateCart();
            }
            //after adding the qty field check if the item already exists in the cart. If so increase the qty;
            //create shopping cart item
            ShoppingCartItem shoppingCartItem = null;
            if (cart.ItemsList != null && cart.ItemsList.Count() >= 0)
            {
                shoppingCartItem = cart.ItemsList.FirstOrDefault(i => i.PartId == partId);
                if (shoppingCartItem != null)
                {
                    shoppingCartItem.Quantity++;
                    dbContext.Update(shoppingCartItem);
                    dbContext.SaveChanges();
                }
                else
                {
                    shoppingCartItem = new ShoppingCartItem();
                    shoppingCartItem.PartId = partId;
                    shoppingCartItem.ShoppingCartId = cart.Id;
                    shoppingCartItem.Quantity = 1;
                    //save ShoppingCatrItem to DB
                    dbContext.Add(shoppingCartItem);
                    dbContext.SaveChanges();

                }
            }        
            return shoppingCartItem;
        }

        private Cart CreateCart()
        {
            var cart = new Cart();
            cart.UserId = Guid.NewGuid().ToString();
            dbContext.Add(cart);
            dbContext.SaveChanges();
            return cart;
        }
    }
}
