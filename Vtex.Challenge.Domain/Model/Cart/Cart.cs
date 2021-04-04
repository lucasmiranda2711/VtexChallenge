using System.Collections.Generic;
using System.Linq;

namespace Vtex.Challenge.Domain.Model.Carts
{
    public class Cart
    {
        public List<Item> items { get; set; } = new List<Item>();

        public decimal GetTotalCartPrice()
        {
            return items.Sum(item => item.GetTotalPrice());
        }
    }
}