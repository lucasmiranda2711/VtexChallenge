using System;

namespace Vtex.Challenge.Domain.Model.Cupoms
{
    public class Cupom
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal DiscountValue { get; set; }
        public bool Available { get; set; }
    }
}