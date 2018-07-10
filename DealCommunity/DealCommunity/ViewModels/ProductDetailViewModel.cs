using System;

namespace DealCommunity
{
    public class ProductDetailViewModel : BaseViewModel
    {
        public Product Item { get; set; }
        public ProductDetailViewModel(Product item = null)
        {
            if (item != null)
            {
                Title = item.Name;
                Item = item;
            }
        }
    }
}
