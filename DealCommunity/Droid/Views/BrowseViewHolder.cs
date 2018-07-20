using System;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace DealCommunity.Droid.Views
{
    public class BrowseViewHolder : RecyclerView.ViewHolder
    {
        public TextView TextView { get; set; }
        public TextView DetailTextView { get; set; }
        public TextView CounterView { get; set; }
        public ImageView ProductPictureView { get; set; }
        public TextView ReleaseDate { get; set; }
        public RatingBar RatingStars { get; set; }

        public BrowseViewHolder(View itemView, Action<RecyclerClickEventArgs> clickListener,
                            Action<RecyclerClickEventArgs> longClickListener) : base(itemView)
        {
            TextView = itemView.FindViewById<TextView>(Android.Resource.Id.Text1);
            DetailTextView = itemView.FindViewById<TextView>(Android.Resource.Id.Text2);
            CounterView = itemView.FindViewById<TextView>(Resource.Id.item_count);
            ProductPictureView = itemView.FindViewById<ImageView>(Resource.Id.product_img);
            ReleaseDate = itemView.FindViewById<TextView>(Resource.Id.release_date);
            RatingStars = itemView.FindViewById<RatingBar>(Resource.Id.rating_bar);
            itemView.Click += (sender, e) => clickListener(new RecyclerClickEventArgs { View = itemView, Position = AdapterPosition });
            itemView.LongClick += (sender, e) => longClickListener(new RecyclerClickEventArgs { View = itemView, Position = AdapterPosition });
        }
    }
}
