
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
            // assign the item an id and set the date created to today
            item.Id = _items.Count + 1;
            item.DateCreated = DateTime.Now;

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

        /// <summary>
        /// Recursively calculates the factorial of the number passed as an argument.
        /// </summary>
        /// <param name="number">the number whose factorial we want to calculate</param>
        /// <returns>Factorial(n)</returns>
        private long factorial(int number)
        {
            if (number == 0 || number == 1) return 1;
            return number * factorial(number - 1);
        }

        private long[]? factorials;
        private Task calculateFactorial(int number, int index)
        {
            Task task = Task.Run(() =>
            {
                Console.WriteLine($"Calculating factorial: {number}, {index}");
                var f = factorial(number);
                if (factorials != null) // this check is merely here to please the compiler. factorials will never be null
                {
                    factorials[index] = f;
                }
                // Thread.Sleep(1000); // simulate delay on a very fast computer
                Console.WriteLine($"Calculated factorial: {number}, {index}");

            });
            return task;
        }

        public async Task<List<long>> Factorial()
        {

            if (_items.Count == 0)
            {
                return new List<long>(); // nothing to do, no items have been added to the list. Return an empty list.
            }
            else
            {
                // the array below will contain the factorials of the numbers.
                factorials = new long[_items.Count];

                // list of tasks to run asynchronously
                List<Task> tasks = new List<Task>();

                // create a task for each index in the list
                for (int i = 0; i < _items.Count; i++)
                {
                    tasks.Add(calculateFactorial(i, i));
                }
                // wait for all tasks to complete
                await Task.WhenAll(tasks);
                return factorials.ToList();
            }

        }


    }
}
