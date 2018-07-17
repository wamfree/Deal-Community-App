using System;
using UIKit;

namespace DealCommunity.iOS
{
    public partial class TabBarController : UITabBarController
    {
        public TabBarController(IntPtr handle) : base(handle)
        {
            TabBar.Items[0].Title = "Products";
            TabBar.Items[1].Title = "About";
        }
    }
}
