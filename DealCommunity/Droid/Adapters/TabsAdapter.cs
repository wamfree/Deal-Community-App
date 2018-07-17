using Android.Content;
using Android.Support.V4.App;

namespace DealCommunity.Droid.Adapters
{
    public class TabsAdapter : FragmentStatePagerAdapter
    {
        string[] titles;

        public override int Count => titles.Length;

        public TabsAdapter(Context context, FragmentManager fm) : base(fm)
        {
            titles = context.Resources.GetTextArray(Resource.Array.sections);
        }

        public override Java.Lang.ICharSequence GetPageTitleFormatted(int position) =>
                            new Java.Lang.String(titles[position]);

        public override Fragment GetItem(int position)
        {
            return BrowseFragment.NewInstance();
        }

        public override int GetItemPosition(Java.Lang.Object frag) => PositionNone;
    }
}
