using System;
using Xamarin.Forms;
using Android.Media;
using pacoILCE.Droid;

[assembly: Dependency(typeof(AudioSerivce))]
namespace pacoILCE.Droid
{
    public class AudioSerivce : IAudio
    {
        int clicks = 0;
        MediaPlayer player;

        public AudioSerivce()
        {
        }

        public bool Play_Pause(string url)
        {
            if (clicks == 0)
            {
                this.player = new MediaPlayer();
                this.player.SetDataSource(url);
                this.player.SetAudioStreamType(Stream.Music);
                this.player.PrepareAsync();
                this.player.Start();
                clicks++;
            }
            else if (clicks % 2 != 0)
            {
                this.player.Pause();
                clicks++;

            }
            else
            {
                this.player.Start();
                clicks++;
            }


            return true;
        }

        public bool Stop(bool val)
        {
            this.player.Stop();
            clicks = 0;
            return true;
        }
    }

}