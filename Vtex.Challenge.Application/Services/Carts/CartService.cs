using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vtex.Challenge.Database.Repository.Auth;
using Vtex.Challenge.Database.Repository.Carts.Interfaces;
using Vtex.Challenge.Domain.Model.Carts;

namespace Vtex.Challenge.Application.Services.Carts
{
    public class CartService : ICartService
    {
        private ICartRepository CartRepository;
        private IUserRepository UserRepository;

        public CartService(ICartRepository cartRepository, IUserRepository userRepository)
        {
            CartRepository = cartRepository;
            UserRepository = userRepository;
        }

        public async Task<Cart> GetCart(Guid id)
        {
            return CartRepository.GetCartById(id);
        }

        public async Task<Guid> CreateCart(int userId)
        {
            var user = await UserRepository.GetById(userId);

            var cart = new Cart()
            {
                Items = new List<CartItem>(),
                User = user
            };

            return CartRepository.CreateCart(cart).Id;
        }

        public async Task<bool> CleanCart(Guid id)
        {
            var cart = CartRepository.GetCartById(id);

            if (cart == null) return false;

            cart?.Items?.Clear();

            CartRepository.UpdateCart(cart);

            return true;
        }
    }
}