using System;
using Android.OS;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Android.Support.V4.Widget;
using Android.Content;
using System.Linq;
using System.Collections.ObjectModel;
using DealCommunity.Droid.Adapters;
using Android.Views.InputMethods;

namespace DealCommunity.Droid
{

    public class BrowseFragment : Android.Support.V4.App.Fragment, IFragmentVisible
    {
        public static BrowseFragment NewInstance() =>
            new BrowseFragment { Arguments = new Bundle() };

        BrowseItemsAdapter adapter;
        SwipeRefreshLayout refresher;
        EditText productSearch;
        RecyclerView recyclerView;
        ObservableCollection<Product> originalItems;
        ProgressBar progress;


        public static ProductViewModel ViewModel { get; set; }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            ViewModel = new ProductViewModel();
            originalItems = ViewModel.Items;

            View view = inflater.Inflate(Resource.Layout.fragment_browse, container, false);
            recyclerView = view.FindViewById<RecyclerView>(Resource.Id.recyclerView);

            recyclerView.HasFixedSize = true;
            recyclerView.SetAdapter(adapter = new BrowseItemsAdapter(Activity, ViewModel));

            refresher = view.FindViewById<SwipeRefreshLayout>(Resource.Id.refresher);
            refresher.SetColorSchemeColors(Resource.Color.accent);

            progress = view.FindViewById<ProgressBar>(Resource.Id.progressbar_loading);
            progress.Visibility = ViewStates.Gone;

            productSearch = view.FindViewById<EditText>(Resource.Id.product_search);
            productSearch.TextChanged += OnProductSearchTextChanged;
            productSearch.KeyPress += OnProductSearchTyped;
           
            return view;
        }

        void OnProductSearchTyped(object sender, View.KeyEventArgs e)
        {
            if (e.Event.Action == KeyEventActions.Down && e.KeyCode == Keycode.Enter)
            {
                e.Handled = true;
                DismissKeyboard();
            }
            else
                e.Handled = false;
        }

        private void DismissKeyboard()
        {
            if (productSearch != null)
            {
                InputMethodManager imm = (InputMethodManager)Activity.GetSystemService(Context.InputMethodService);
                imm.HideSoftInputFromWindow(productSearch.WindowToken, 0);
            }
        }

        private void OnProductSearchTextChanged(object sender, Android.Text.TextChangedEventArgs e)
        {
            var productList = (from item in originalItems
                               where item.Name.Contains(productSearch.Text) || item.Description.Contains(productSearch.Text)
                               select item).ToList<Product>();

            ViewModel.Items = new ObservableCollection<Product>(productList);

            recyclerView.SetAdapter(adapter = new BrowseItemsAdapter(Activity, ViewModel));
            adapter.ItemClick += Adapter_ItemClick;
        } 

        public override void OnStart()
        {
            base.OnStart();

            refresher.Refresh += Refresher_Refresh;
            adapter.ItemClick += Adapter_ItemClick;

            if (ViewModel.Items.Count == 0)
                ViewModel.LoadItemsCommand.Execute(null);
        }

        public override void OnStop()
        {
            base.OnStop();
            refresher.Refresh -= Refresher_Refresh;
            adapter.ItemClick -= Adapter_ItemClick;
        }

        void Adapter_ItemClick(object sender, RecyclerClickEventArgs e)
        {
            var item = ViewModel.Items[e.Position];
            var intent = new Intent(Activity, typeof(BrowseItemDetailActivity));

            intent.PutExtra("data", Newtonsoft.Json.JsonConvert.SerializeObject(item));
            Activity.StartActivity(intent);
        }

        void Refresher_Refresh(object sender, EventArgs e)
        {
            ViewModel.LoadItemsCommand.Execute(null);
            refresher.Refreshing = false;
        }

        public void BecameVisible(){}
    }
}
