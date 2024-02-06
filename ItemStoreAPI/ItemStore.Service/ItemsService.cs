
using ItemStore.Data;
using ItemStore.Domain.Entities;

namespace ItemStore.Service
{
    public class ItemsService : IItemsService
    {
        private readonly IItemsRepository itemsRepository;

        public ItemsService(IItemsRepository itemsRepository)
        {
            this.itemsRepository = itemsRepository;
        }

        public Item AddItem(Item item)
        {
            return itemsRepository.AddItem(item);
        }

        public bool Delete(int id)
        {
            return itemsRepository.Delete(id);
        }

        public Item? Get(int id)
        {
            return itemsRepository.Get(id);
        }

        public IEnumerable<Item> GetAll()
        {
            return itemsRepository.GetAll();
        }

        public IEnumerable<Item> Search(string name)
        {
            return itemsRepository.Search(name);
        }

        public Item Update(Item item)
        {
            return itemsRepository.Update(item);
        }
    }
}
