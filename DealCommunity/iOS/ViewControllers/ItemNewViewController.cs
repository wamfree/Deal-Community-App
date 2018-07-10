using System;

using UIKit;

namespace DealCommunity.iOS
{
    public partial class ItemNewViewController : UIViewController
    {
        public ProductsViewModel ViewModel { get; set; }

        public ItemNewViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            btnSaveItem.TouchUpInside += (sender, e) =>
            {
                var item = new Product
                {
                    Name = txtTitle.Text,
                    Description = txtDesc.Text
                };
                ViewModel.AddItemCommand.Execute(item);
                NavigationController.PopToRootViewController(true);
            };
        }
    }
}
