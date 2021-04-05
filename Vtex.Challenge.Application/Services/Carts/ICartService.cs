using System;
using System.Threading.Tasks;
using Vtex.Challenge.Application.Services.Items;
using Vtex.Challenge.Domain.Model.Carts;

namespace Vtex.Challenge.Application.Services.Carts
{
    public interface ICartService
    {
        Task<Cart> GetCart(Guid Id);

        Task<Guid> CreateCart(int userId);

        Task<bool> CleanCart(Guid id);
        Task<bool> AddCupom(Guid CartId, Guid CupomId);
        Task<bool> AddItem(ItemRequestDto itemRequestDto);
        Task<bool> RemoveItem(Guid cartId, Guid itemId);
        Task<bool> UpdateItem(ItemRequestDto itemRequestDto);
    }
}