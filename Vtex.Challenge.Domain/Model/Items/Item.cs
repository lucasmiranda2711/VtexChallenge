using System;

namespace Vtex.Challenge.Domain.Model.Items
{
    public class Item
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}