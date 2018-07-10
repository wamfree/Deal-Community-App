using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using DealCommunityShared.Models;
using Newtonsoft.Json;

namespace DealCommunityShared.ViewModels
{
    public class ProductViewModel
    {
        public ObservableCollection<Product> Products { get; } = new ObservableCollection<Product>();

        public async Task GetProductsAsync()
        {
            try
            {
                var client = new HttpClient();
                var json = await client.GetStringAsync("http://www.devtiberiuoprea.com/products.json");

                var items = JsonConvert.DeserializeObject<List<Product>>(json);

                foreach(var item in items)
                {
                    Products.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        public ProductViewModel()
        {
        }
    }
}
