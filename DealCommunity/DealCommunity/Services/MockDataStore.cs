using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DealCommunity
{
    public class MockDataStore : IDataStore<Product>
    {
        List<Product> items;

        public MockDataStore()
        {
            items = new List<Product>();
            var _items = new List<Product>
            {
            };

            foreach (Product item in _items)
            {
                items.Add(item);
            }
        }

        public async Task<bool> AddItemAsync(Product item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Product item)
        {
            var _item = items.Where((Product arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(_item);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var _item = items.Where((Product arg) => arg.Id == id).FirstOrDefault();
            items.Remove(_item);

            return await Task.FromResult(true);
        }

        public async Task<Product> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Product>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}
