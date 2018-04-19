using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pacoILCE.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace pacoILCE
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MusicUI : ContentPage
	{
		public MusicUI ()
		{
			InitializeComponent ();
		    var play = new Button()
		    {
		        Text = "Play/Pause",
		        VerticalOptions = LayoutOptions.CenterAndExpand,
		        HorizontalOptions = LayoutOptions.StartAndExpand,
		        Command = new Command(() =>
		        {
		            DependencyService.Get<IAudio>().Play_Pause("http://201.159.130.34:8080/radioilce.mp3");
		        })
		    };
		    var stop = new Button()
		    {
		        Text = " Stop ",
		        VerticalOptions = LayoutOptions.CenterAndExpand,
		        HorizontalOptions = LayoutOptions.StartAndExpand,
		        Command = new Command(() =>
		        {
		            DependencyService.Get<IAudio>().Stop(true);
		        })
		    };

		    StackLayout holder = new StackLayout()
		    {
		        Orientation = StackOrientation.Horizontal,
		        VerticalOptions = LayoutOptions.CenterAndExpand,
		        HorizontalOptions = LayoutOptions.CenterAndExpand,
		        Children = { play, stop }
		    };
		    Content = new StackLayout()
		    {
		        Children = { holder }
		    };
        }

	}
}