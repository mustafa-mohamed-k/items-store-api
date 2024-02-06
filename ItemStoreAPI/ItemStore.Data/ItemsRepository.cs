
using ItemStore.Domain.Entities;

namespace ItemStore.Data
{
    public class ItemsRepository : IItemsRepository
    {

        private readonly List<Item> _items;

        public ItemsRepository()
        {
            _items = new List<Item>();
        }

        public Item AddItem(Item item)
        {
            // assign the item an id
            item.Id = _items.Count + 1;

            _items.Add(item);
            return item;
        }

        public bool Delete(int id)
        {
            bool removed = false;
            var item = _items.Find(item => item.Id == id);
            if (item != null)
            {
                _items.Remove(item);
                removed = true;
            }
            return removed;
        }

        public Item? Get(int id)
        {
            return _items.Find(item => item.Id == id);
        }

        public IQueryable<Item> GetAll()
        {
            return _items.AsQueryable();
        }

        public IQueryable<Item> Search(string name)
        {
            return _items.AsQueryable().Where(x => x.Name == name);
        }

        public Item Update(Item item)
        {
            int id = item.Id;
            var existingItem = _items.Find(x => x.Id == id);
            if (existingItem == null)
            {
                throw new Exception("Item not found");
            }
            existingItem.Name = item.Name;
            existingItem.Description = item.Description;
            return existingItem;
        }
    }
}
