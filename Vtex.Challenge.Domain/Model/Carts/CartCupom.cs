using System;
using Vtex.Challenge.Domain.Model.Cupoms;

namespace Vtex.Challenge.Domain.Model.Carts
{
    public class CartCupom
    {
        public Guid CartId { get; set; }
        public Cupom Cupom { get; set; }

        public decimal GetTotalDiscount()
        {
            return Cupom.Available ? Cupom.DiscountValue : 0;
        }
    }
}