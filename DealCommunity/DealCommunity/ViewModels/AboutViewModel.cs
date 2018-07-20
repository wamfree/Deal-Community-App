using System.Windows.Input;

namespace DealCommunity
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "About";

            OpenWebCommand = new Command(() => Plugin.Share.CrossShare.Current.OpenBrowser("https://www.linkedin.com/in/tiberiuoprea"));
        }

        public ICommand OpenWebCommand { get; }
    }
}
