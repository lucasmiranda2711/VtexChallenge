using System;
using Vtex.Challenge.Domain.Model.Carts;

namespace Vtex.Challenge.Database.Repository.Carts.Interfaces
{
    public interface ICartRepository
    {
        Cart FindById(Guid id);

        Cart Create(Cart cart);

        void Update(Cart cart);
    }
}