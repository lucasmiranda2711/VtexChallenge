using System;
using Vtex.Challenge.Domain.Model.Items;

namespace Vtex.Challenge.Domain.Model.Carts
{
    public class CartItem
    {
        public Item Item { get; set; }
        public Guid CartId { get; set; }
        public int ItemQuantity { get; set; }

        public decimal GetTotalPrice()
        {
            return ItemQuantity * Item.Price;
        }
    }
}