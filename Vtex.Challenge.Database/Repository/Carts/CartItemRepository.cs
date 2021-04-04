using System.Collections.Generic;
using Vtex.Challenge.Database.Repository.Carts.Interfaces;
using Vtex.Challenge.Domain.Model.Carts;

namespace Vtex.Challenge.Database.Repository.Carts
{
    public class CartItemRepository : ICartItemRepository
    {
        public static List<CartItem> cartItems = new List<CartItem>();
    }
}