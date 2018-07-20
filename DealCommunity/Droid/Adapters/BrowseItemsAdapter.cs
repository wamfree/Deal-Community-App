using System.Net;
using Android.App;
using Android.Graphics;
using Android.Media;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using DealCommunity.Droid.Views;

namespace DealCommunity.Droid.Adapters
{
    public class BrowseItemsAdapter : BaseRecycleViewAdapter
    {
        ProductViewModel viewModel;
        Activity activity;

        public BrowseItemsAdapter(Activity activity, ProductViewModel viewModel)
        {
            this.viewModel = viewModel;
            this.activity = activity;

            this.viewModel.Items.CollectionChanged += (sender, args) =>
            {
                this.activity.RunOnUiThread(NotifyDataSetChanged);
            };
        }

        // Create new views (invoked by the layout manager)
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            //Setup your layout here
            View itemView = null;
            var id = Resource.Layout.item_my_item;
            itemView = LayoutInflater.From(parent.Context).Inflate(id, parent, false);

            var vh = new BrowseViewHolder(itemView, OnClick, OnLongClick);
            return vh;
        }

        // Replace the contents of a view (invoked by the layout manager)
        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            var item = viewModel.Items[position];

            // Replace the contents of the view with that element
            var myHolder = holder as BrowseViewHolder;
            myHolder.TextView.Text = item.Name;
            myHolder.DetailTextView.Text = item.Description;
            myHolder.CounterView.Text = "CHF\n" + item.Price;
            myHolder.ReleaseDate.Text = "Release date: " + item.ReleaseDate;
            float starsValue;
            float.TryParse(item.StarRating, out starsValue);
            myHolder.RatingStars.Rating = starsValue;
            myHolder.RatingStars.NumStars = 5;
                    
            var imageBitmap = GetImageBitmapFromUrl(item.ImageUrl);
            myHolder.ProductPictureView.SetImageBitmap(imageBitmap);
        }

        public override int ItemCount => viewModel.Items.Count;

        private Bitmap GetImageBitmapFromUrl(string url)
        {
            Bitmap imageBitmap = null;

            using (var webClient = new WebClient())
            {
                var imageBytes = webClient.DownloadData(url);
                if (imageBytes != null && imageBytes.Length > 0)
                {
                    imageBitmap = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
                }
            }

            return imageBitmap;
        }
    }
}
