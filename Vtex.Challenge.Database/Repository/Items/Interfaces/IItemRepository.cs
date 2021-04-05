using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vtex.Challenge.Domain.Model.Items;

namespace Vtex.Challenge.Database.Repository.Items.Interfaces
{
    public interface IItemRepository
    {
        Task<Item> FindById(Guid id);
        Task<IList<Item>> FindAll();
        void Update(Item item);
    }
}
