using System.Linq;
using TestAPI.Entities;

namespace TestAPI.Repositories
{
    public class InMemItemsRepository : IItemsRepository
    {

        private readonly List<Item> items = new()
        {
            new Item { id = Guid.NewGuid(), name = "Potion", price = 9, createdDate = DateTimeOffset.Now },
            new Item { id = Guid.NewGuid(), name = "Iron Sword", price = 20, createdDate = DateTimeOffset.Now },
            new Item { id = Guid.NewGuid(), name = "Bronze Shield", price = 18, createdDate = DateTimeOffset.Now },
        };


        public IEnumerable<Item> GetItems()
        {
            return this.items;
        }

        public Item GetItem(Guid id)
        {
            return this.items.Where(item => item.id == id).FirstOrDefault();
        }

        public void CreateItem(Item item)
        {
            this.items.Add(item);
        }

        public void UpdateItem(Item item)
        {
            var index = this.items.FindIndex(existingItem => existingItem.id == item.id);
            items[index] = item;
        }

        public void DeleteItem(Guid id)
        {
            var index = this.items.FindIndex(item => item.id == id);
            items.RemoveAt(index);
        }
    }
}
