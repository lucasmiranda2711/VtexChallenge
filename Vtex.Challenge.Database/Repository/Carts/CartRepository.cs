using System;
using System.Collections.Generic;
using System.Linq;
using Vtex.Challenge.Database.Repository.Carts.Interfaces;
using Vtex.Challenge.Domain.Model.Carts;

namespace Vtex.Challenge.Database.Repository.Carts
{
    public class CartRepository : ICartRepository
    {
        public static List<Cart> carts = new List<Cart>();

        public Cart GetCartById(Guid id)
        {
            return carts.FirstOrDefault(cart => cart.Id == id);
        }

        public Cart CreateCart(Cart cart)
        {
            cart.Id = Guid.NewGuid();

            carts.Add(cart);

            return cart;
        }

        public void UpdateCart(Cart cart)
        {
            carts[carts.FindIndex(c => c.Id == cart.Id)] = cart;
        }
    }
}