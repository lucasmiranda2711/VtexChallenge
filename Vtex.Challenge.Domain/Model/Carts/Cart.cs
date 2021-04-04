using System;
using System.Collections.Generic;
using System.Linq;
using Vtex.Challenge.Domain.Model.Auth;

namespace Vtex.Challenge.Domain.Model.Carts
{
    public class Cart
    {
        public Guid Id { get; set; }
        public User User { get; set; }
        public List<CartItem> Items { get; set; } = new List<CartItem>();
        public List<CartCupom> Cupoms { get; set; } = new List<CartCupom>();

        public decimal GetTotalCartPrice()
        {
            return Items.Sum(item => item.GetTotalPrice()) - GetTotalDiscount();
        }

        public decimal GetTotalDiscount()
        {
            return Cupoms.Sum(cupom => cupom.GetTotalDiscount());
        }
    }
}