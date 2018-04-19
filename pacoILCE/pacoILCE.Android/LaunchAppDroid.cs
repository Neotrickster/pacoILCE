using System.Threading.Tasks;
using Android.Content;
using pacoILCE.Interfaces;
using Plugin.CurrentActivity;

namespace pacoILCE.Droid
{
    public class LaunchAppDroid : IAppHandler
    {
        public Task<bool> LaunchApp(string uri)
        {
            bool result = false;

            try
            {
                var aUri = Android.Net.Uri.Parse(uri.ToString());
                var intent = new Intent(Intent.ActionView, aUri);
                Xamarin.Forms.Forms.Context.StartActivity(intent);
                /*La solución de https://forums.xamarin.com/discussion/106938/context-is-obsolete-as-of-version-2-5 no ayuda al no estar desarrollada para .net standar 2.0*/
                //CrossCurrentActivity.Current.Activity.StartActivity(intent);
                result = true;
            }
            catch (ActivityNotFoundException)
            {
                result = false;
            }

            return Task.FromResult(result);
        }
    }
}