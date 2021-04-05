using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vtex.Challenge.Domain.Model.Items;

namespace Vtex.Challenge.Application.Services.Items
{
    public interface IItemService
    {
        Task<IList<Guid>> GetAllItems();
        Task<Item> GetItem(Guid id);
        Task<Item> GetItemUpdatingQUantity(Guid id, int quantity);

    }
}
