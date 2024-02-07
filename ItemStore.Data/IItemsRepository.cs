
using ItemStore.Domain.Entities;

namespace ItemStore.Data
{
    public interface IItemsRepository
    {
        Item AddItem(Item item);

        IQueryable<Item> GetAll();

        IQueryable<Item> Search(string name);


        Item? Get(int id);

        Item Update(Item item);

        bool Delete(int id);
    }
}
