using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vtex.Challenge.Application.Services.Cupoms;
using Vtex.Challenge.Database.Repository.Auth;
using Vtex.Challenge.Database.Repository.Carts.Interfaces;
using Vtex.Challenge.Domain.Model.Carts;

namespace Vtex.Challenge.Application.Services.Carts
{
    public class CartService : ICartService
    {
        private ICartRepository CartRepository;
        private IUserRepository UserRepository;
        private ICupomService CupomService;

        public CartService(ICartRepository cartRepository, IUserRepository userRepository, ICupomService cupomService)
        {
            CartRepository = cartRepository;
            UserRepository = userRepository;
            CupomService = cupomService;
        }

        public async Task<Cart> GetCart(Guid id)
        {
            return CartRepository.FindById(id);
        }

        public async Task<Guid> CreateCart(int userId)
        {
            var user = await UserRepository.GetById(userId);

            var cart = new Cart()
            {
                Items = new List<CartItem>(),
                User = user
            };

            return CartRepository.Create(cart).Id;
        }

        public async Task<bool> CleanCart(Guid id)
        {
            var cart = CartRepository.FindById(id);

            if (cart == null) return false;

            cart?.Items?.Clear();

            CartRepository.Update(cart);

            return true;
        }

        public async Task<bool> AddCupom(Guid CartId, Guid CupomId)
        {
            var cart = CartRepository.FindById(CartId);
            var cupom = await CupomService.GetCupom(CupomId);
            
            if (cart == null || cupom == null) return false;

            cart.Cupoms.Add(new CartCupom() { CartId = cart.Id, Cupom = cupom});

            CartRepository.Update(cart);

            return true;
        }
    }
}