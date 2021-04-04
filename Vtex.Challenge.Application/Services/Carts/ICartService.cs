using System;
using System.Threading.Tasks;
using Vtex.Challenge.Domain.Model.Carts;

namespace Vtex.Challenge.Application.Services.Carts
{
    public interface ICartService
    {
        Task<Cart> GetCart(Guid Id);

        Task<Guid> CreateCart(int userId);

        Task<bool> CleanCart(Guid id);
    }
}