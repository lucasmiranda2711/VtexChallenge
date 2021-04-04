using System;
using Vtex.Challenge.Domain.Model.Carts;

namespace Vtex.Challenge.Database.Repository.Carts.Interfaces
{
    public interface ICartRepository
    {
        Cart GetCartById(Guid id);

        Cart CreateCart(Cart cart);

        void UpdateCart(Cart cart);
    }
}