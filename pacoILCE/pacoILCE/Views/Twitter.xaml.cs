using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pacoILCE.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace pacoILCE
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Twitter : ContentPage
	{
		public Twitter ()
		{
			InitializeComponent ();
		    BindingContext = new TwitterViewModel();

		    var htmlSource = new HtmlWebViewSource();
            //htmlSource.Html = @"<html><body>
            //                          <h1>Twitter Feed</h1>
            //                          <p>ILCE</p>
            //                          <a class='twitter - timeline' href='https://mobile.twitter.com/ILCEedu'>Twitter ILCE</a>
            //                    <script async src = 'https://platform.twitter.com/widgets.js' charset = 'utf-8' ></ script >
            //                          </body></html>";
            //TwitterWebView.Source = htmlSource;
		    TwitterWebView.Source = "https://mobile.twitter.com/ILCEedu";
        }
	}
}