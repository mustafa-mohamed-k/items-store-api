
using ItemStore.Domain.Entities;

namespace ItemStore.Service
{
    public interface IItemsService
    {
        Item AddItem(Item item);

        IEnumerable<Item> GetAll();

        IEnumerable<Item> Search(string name);


        Item? Get(int id);

        Item Update(Item item);

        bool Delete(int id);
    }
}
