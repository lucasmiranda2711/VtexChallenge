using System;
using System.Threading.Tasks;
using Vtex.Challenge.Domain.Model.Carts;

namespace Vtex.Challenge.Application.Services.Carts
{
    public class CartService : ICartService
    {

        public async Task<Cart> GetCart(int Id)
        {
            return new Cart();
        }

        public Cart CreateCart()
        {
            throw new NotImplementedException();
        }

        public Cart UpdateCart()
        {
            throw new NotImplementedException();
        }

        public void DeleteCart()
        {
            throw new NotImplementedException();
        }
    }
}