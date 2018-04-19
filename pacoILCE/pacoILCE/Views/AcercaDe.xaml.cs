using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pacoILCE.Interfaces;
using pacoILCE.ViewModels;
using Plugin.Share;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace pacoILCE
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AcercaDe : ContentPage
	{
	    void OpenBrowser(string url)
	    {
	        CrossShare.Current.OpenBrowser(url, new Plugin.Share.Abstractions.BrowserOptions
	        {
	            ChromeShowTitle = true,
	            ChromeToolbarColor = new Plugin.Share.Abstractions.ShareColor { R = 3, G = 169, B = 244, A = 255 },
	            UseSafariReaderMode = true,
	            UseSafariWebViewController = true
	        });
	    }
        public AcercaDe ()
		{
			InitializeComponent();
		    BindingContext = new AcercaDeViewModel();

		    twitter.GestureRecognizers.Add(new TapGestureRecognizer()
		    {
		        Command = new Command(async () =>
		        {
                    //try to launch twitter or tweetbot app, else launch browser
                    /*var launch = DependencyService.Get<ILaunchTwitter>();
		            if (launch == null || !launch.OpenUserName("ILCEedu"))
		                OpenBrowser("http://m.twitter.com/ILCEedu");*/

                    //Device.OpenUri(new Uri("twitter://user?user_id=472217141"));
		            bool x = await DependencyService.Get<IAppHandler>().LaunchApp("twitter://user?user_id=472217141");
		            if (!x)
		            {
		                OpenBrowser("http://m.twitter.com/ILCEedu");
                    }
		        })
		    });

		    facebook.GestureRecognizers.Add(new TapGestureRecognizer()
		    {
		        Command = new Command(async () =>
		        {
		            //OpenBrowser("https://m.facebook.com/ILCEoficial");
                    //Device.OpenUri(new Uri("fb://page/108372002521167"));
		            bool y = await DependencyService.Get<IAppHandler>().LaunchApp("fb://page/108372002521167");
		            if (!y)
		            {
		                OpenBrowser("https://m.facebook.com/ILCEoficial");
                    }
                })
            });
        }
	}
}