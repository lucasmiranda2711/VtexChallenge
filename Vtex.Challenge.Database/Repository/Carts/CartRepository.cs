using System;
using System.Collections.Generic;
using System.Linq;
using Vtex.Challenge.Database.Repository.Carts.Interfaces;
using Vtex.Challenge.Domain.Model.Carts;

namespace Vtex.Challenge.Database.Repository.Carts
{
    public class CartRepository : ICartRepository
    {
        private static List<Cart> carts = new List<Cart>();

        public Cart FindById(Guid id)
        {
            return carts.FirstOrDefault(cart => cart.Id == id);
        }

        public Cart Create(Cart cart)
        {
            cart.Id = Guid.NewGuid();

            carts.Add(cart);

            return cart;
        }

        public void Update(Cart cart)
        {
            carts[carts.FindIndex(c => c.Id == cart.Id)] = cart;
        }
    }
}