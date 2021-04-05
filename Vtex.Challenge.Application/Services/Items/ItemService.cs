using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vtex.Challenge.Database.Repository.Items.Interfaces;
using Vtex.Challenge.Domain.Model.Items;

namespace Vtex.Challenge.Application.Services.Items
{
    public class ItemService : IItemService
    {
        IItemRepository ItemRepository;

        public ItemService(IItemRepository itemRepository)
        {
            ItemRepository = itemRepository;
        }

        public async Task<IList<Guid>> GetAllItems()
        {
            return (await ItemRepository.FindAll()).Select(item => item.Id).ToList();
        }

        public async Task<Item> GetItem(Guid id)
        {
            return await ItemRepository.FindById(id);
        }

        public async Task<Item> GetItemUpdatingQUantity(Guid id, int quantity)
        {
            var item = await ItemRepository.FindById(id);

            if (item == null || item.Quantity < quantity) return null;

            item.Quantity = item.Quantity - quantity;

            ItemRepository.Update(item);

            return item;
        }
    }
}
