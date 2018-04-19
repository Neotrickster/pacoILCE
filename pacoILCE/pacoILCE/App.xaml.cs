using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using pacoILCE.Views;
using Plugin.MediaManager.Forms;
using Xamarin.Forms;

namespace pacoILCE
{
	public partial class App : Application
	{
		public App ()
		{
		    var workaround = typeof(VideoView);
            InitializeComponent();

            //MainPage = new pacoILCE.MainPage();
            MainPage = new RootPage();
		    //MainPage = new MusicUI();
        }

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
