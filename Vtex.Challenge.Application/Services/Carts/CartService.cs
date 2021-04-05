using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vtex.Challenge.Application.Services.Cupoms;
using Vtex.Challenge.Application.Services.Items;
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
        private IItemService ItemService;

        public CartService(ICartRepository cartRepository, IUserRepository userRepository, 
            ICupomService cupomService, IItemService itemService)
        {
            CartRepository = cartRepository;
            UserRepository = userRepository;
            CupomService = cupomService;
            ItemService = itemService;
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

        public async Task<bool> AddItem(ItemRequestDto itemRequestDto)
        {
            var cart = CartRepository.FindById(itemRequestDto.CartId);
            var item = await ItemService.GetItemUpdatingQUantity(itemRequestDto.ItemId, itemRequestDto.ItemQuantity);
            if (cart == null || item == null) return false;

            cart.Items.Add(new CartItem() { CartId = cart.Id, Item = item, ItemQuantity = itemRequestDto.ItemQuantity });

            CartRepository.Update(cart);

            return true;
        }

        public async Task<bool> RemoveItem(Guid cartId, Guid itemId)
        {
            var cart = CartRepository.FindById(cartId);
            var item = cart?.Items != null ? await ItemService
                .GetItemUpdatingQUantity(itemId, cart.Items.FirstOrDefault(i=> i.Item.Id == itemId).ItemQuantity * -1)
                : await ItemService.GetItem(itemId);
            if (cart == null || item == null) return false;


            cart.Items.Remove(cart.Items.FirstOrDefault(c => c.Item.Id == item.Id));
            
            CartRepository.Update(cart);

            return true;
        }

        public async Task<bool> UpdateItem(ItemRequestDto itemRequestDto)
        {
            var cart = CartRepository.FindById(itemRequestDto.CartId);
            
            var item = cart?.Items != null ? await ItemService
                .GetItemUpdatingQUantity(itemRequestDto.ItemId, itemRequestDto.ItemQuantity - cart.Items
                .FirstOrDefault(i => i.Item.Id == itemRequestDto.ItemId).ItemQuantity)
                : await ItemService.GetItem(itemRequestDto.ItemId);

            if (cart == null || item == null) return false;


            var cartItem = cart.Items.FirstOrDefault(c => c.Item.Id == item.Id);
            cartItem.ItemQuantity = itemRequestDto.ItemQuantity;

            var index = cart.Items.IndexOf(cartItem);

            if (index != -1)
                cart.Items[index].Item = item;

            CartRepository.Update(cart);

            return true;
        }
    }
}