using System.Net;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Widget;

namespace DealCommunity.Droid
{
    [Activity(Label = "Details", ParentActivity = typeof(MainActivity))]
    [MetaData("android.support.PARENT_ACTIVITY", Value = ".MainActivity")]
    public class BrowseItemDetailActivity : BaseActivity
    {
        /// <summary>
        /// Specify the layout to inflace
        /// </summary>
        protected override int LayoutResource => Resource.Layout.activity_item_details;

        ProductDetailViewModel viewModel;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            var data = Intent.GetStringExtra("data");

            var item = Newtonsoft.Json.JsonConvert.DeserializeObject<Product>(data);
            viewModel = new ProductDetailViewModel(item);

            FindViewById<TextView>(Resource.Id.description).Text = item.Description;
            FindViewById<TextView>(Resource.Id.release_date).Text = "Release date: " + item.ReleaseDate;
            var ratingBar = FindViewById<RatingBar>(Resource.Id.rating_bar);
            float starsValue;
            float.TryParse(item.StarRating, out starsValue);
            ratingBar.Rating = starsValue;
            ratingBar.NumStars = 5;
            SupportActionBar.Title = item.Name;

            var imageBitmap = GetImageBitmapFromUrl(item.ImageUrl);
            FindViewById<ImageView>(Resource.Id.product_img).SetImageBitmap(imageBitmap);
        }

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

        protected override void OnStart()
        {
            base.OnStart();
        }

        protected override void OnStop()
        {
            base.OnStop();
        }
    }
}
