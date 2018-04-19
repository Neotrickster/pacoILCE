using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Plugin.MediaManager.Forms.Android;

namespace pacoILCE.Droid
{
    [Activity(Label = "pacoILCE", Icon = "@drawable/ilceicono", Theme = "@style/MainTheme", MainLauncher = true,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation,
        ScreenOrientation = ScreenOrientation.Portrait) //fijar la orientación a portrait
    ]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            VideoViewRenderer.Init();

            global::Xamarin.Forms.Forms.Init(this, bundle);

            //Xamarians.MediaPlayer.Droid.VideoPlayerRenderer.Init(this);
            Xamarin.Forms.DependencyService.Register<LaunchAppDroid>();

            LoadApplication(new App());
        }
    }
}

