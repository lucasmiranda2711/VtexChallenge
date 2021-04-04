using Vtex.Challenge.Domain.Model.Items;

namespace Vtex.Challenge.Domain.Model.Carts
{
    public class CartItem
    {
        public Item Item { get; set; }
        public Cart Cart { get; set; }

        public decimal GetTotalPrice()
        {
            return Item.Quantity * Item.Price;
        }
    }
}