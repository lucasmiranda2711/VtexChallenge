namespace Vtex.Challenge.Domain.Model.Carts
{
    public class Item
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public decimal GetTotalPrice()
        {
            return Quantity * Price;
        }
    }
}