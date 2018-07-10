using System;
using UIKit;

namespace DealCommunity.iOS
{
    public partial class BrowseItemDetailViewController : UIViewController
    {
        public ProductDetailViewModel ViewModel { get; set; }
        public BrowseItemDetailViewController(IntPtr handle) : base(handle) { }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            Title = ViewModel.Title;
            ItemNameLabel.Text = ViewModel.Item.Name;
            ItemDescriptionLabel.Text = ViewModel.Item.Description;
        }
    }
}
