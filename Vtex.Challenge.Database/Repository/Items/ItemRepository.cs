using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vtex.Challenge.Database.Repository.Items.Interfaces;
using Vtex.Challenge.Domain.Model.Items;

namespace Vtex.Challenge.Database.Repository.Items
{
    public class ItemRepository : IItemRepository
    {
        private static IList<Item> Items = new List<Item>() 
        { new Item() { Id = Guid.NewGuid(), Name = "TV", Price = 1000, Quantity = 30},
          new Item() { Id = Guid.NewGuid(), Name = "Freezer", Price = 100, Quantity = 2500},
          new Item() { Id = Guid.NewGuid(), Name = "Microwave", Price = 100, Quantity = 800} };
        public async Task<IList<Item>> FindAll()
        {
            return Items;
        }

        public async Task<Item> FindById(Guid id)
        {
            return Items.FirstOrDefault(cupom => cupom.Id == id);
        }

        public void Update(Item item)
        {
            var itemToUpdate = Items.FirstOrDefault(i => i.Id == item.Id);
            var index = Items.IndexOf(itemToUpdate);
            
            if (index != -1)
                Items[index] = item;
        }
    }
}
