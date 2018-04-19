using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pacoILCE.ViewModels;
using Plugin.MediaManager;
using Plugin.MediaManager.Abstractions.Enums;
using Plugin.MediaManager.Abstractions.EventArguments;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace pacoILCE.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class CanalIberoamericano : ContentPage
	{
	    private string videoUrl = "http://apreal04.triara.com:1935/redirect/canaliberoamericano1/live.mp4?scheme=m3u8";
        public CanalIberoamericano ()
		{
			InitializeComponent ();
		    BindingContext = new CanalIberoamericanoViewModel();

		}

	    protected override void OnAppearing()
	    {
	        base.OnAppearing();
	        CrossMediaManager.Current.Stop();
	        CrossMediaManager.Current.StatusChanged += CurrentOnStatusChanged;
            //CrossMediaManager.Current.PlayingChanged += OnPlayingChanged;
            //player.Source = item.VideoUrls.First().Url;
            PlayButton.Clicked += PlayButton_OnClicked;
            StopButton.Clicked += StopButton_OnClicked;
            //pause.Clicked += OnPauseClicked;
            //player.AspectMode = VideoAspectMode.AspectFit;
	        PlayButton.IsEnabled = true;
	        StopButton.IsEnabled = false;
	        PlayButton.IsVisible = true;
	        StopButton.IsVisible = false;
	        StatusLabel.Text = "";
        }

        //private void OnPlayingChanged(object sender, PlayingChangedEventArgs e)
        //{
        //    Device.BeginInvokeOnMainThread(() =>
        //    {
        //        progress.Progress = e.Progress;
        //        Duracion.Text = "" + e.Duration.TotalSeconds + " segundos";
        //        Posicion.Text = "" + e.Position.TotalSeconds + " segundos";
        //    });
        //}

        protected override void OnDisappearing()
	    {
	        base.OnDisappearing();
	        CrossMediaManager.Current.Stop();
	        PlayButton.Clicked -= PlayButton_OnClicked;
	        StopButton.Clicked -= StopButton_OnClicked;
            CrossMediaManager.Current.StatusChanged -= CurrentOnStatusChanged;
	        //CrossMediaManager.Current.PlayingChanged -= OnPlayingChanged;
            //PlayButton.IsEnabled = true;
            //StopButton.IsEnabled = false;
            //PlayButton.IsVisible = true;
            //StopButton.IsVisible = false;
            //StatusLabel.Text = "";
        }

        //   private async void PlayStopButton_OnClicked(object sender, EventArgs e)
        //{
        //    if (PlayStopButton.Text == "Play")
        //    {
        //        await CrossMediaManager.Current.Play(videoUrl, MediaFileType.Video);
        //        PlayStopButton.Text = "Stop";
        //    }
        //    else if (PlayStopButton.Text == "Stop")
        //    {
        //        await CrossMediaManager.Current.Stop();
        //        PlayStopButton.Text = "Play";
        //    }
        //   }

        private double _width = 0;
	    private double _height = 0;

	    protected override void OnSizeAllocated(double width, double height)
	    {
	        base.OnSizeAllocated(width, height); //must be called
	        if (this._width != width || this._height != height)
	        {
	            this._width = width;
	            this._height = height;
                //reconfigurar layout cuando se gira el teléfono
	            if (width > height)
	            {
	                outerStack.Orientation = StackOrientation.Horizontal;
	            }
	            else
	            {
	                outerStack.Orientation = StackOrientation.Vertical;
	            }
            }
	    }

        private async void PlayButton_OnClicked(object sender, EventArgs e)
        {
            //await CrossMediaManager.Current.Play(videoUrl, MediaFileType.Video);
            MyVideoView.Source = videoUrl;
            await CrossMediaManager.Current.VideoPlayer.Play();
            PlayButton.IsEnabled = false;
            StopButton.IsEnabled = true;
            PlayButton.IsVisible = false;
            StopButton.IsVisible = true;
        }

	    private async void StopButton_OnClicked(object sender, EventArgs e)
	    {
	        await CrossMediaManager.Current.Stop();
            PlayButton.IsEnabled = true;
	        StopButton.IsEnabled = false;
	        PlayButton.IsVisible = true;
	        StopButton.IsVisible = false;
        }

        private void CurrentOnStatusChanged(object sender, StatusChangedEventArgs statusChangedEventArgs)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                var status = statusChangedEventArgs.Status;
                switch (status)
                {
                    case MediaPlayerStatus.Stopped:
                        //pause.IsEnabled = false;
                        //stop.IsEnabled = false;
                        StatusLabel.Text = "Detenido";
                        await StatusLabel.FadeTo(1);
                        break;
                    case MediaPlayerStatus.Paused:
                        //pause.IsEnabled = true;
                        //stop.IsEnabled = true;
                        StatusLabel.Text = "Pausado";
                        await StatusLabel.FadeTo(1);
                        break;
                    case MediaPlayerStatus.Playing:
                        //pause.IsEnabled = true;
                        //stop.IsEnabled = true;
                        await StatusLabel.FadeTo(0);
                        break;
                    case MediaPlayerStatus.Loading:
                        //pause.IsEnabled = false;
                        //stop.IsEnabled = false;
                        StatusLabel.Text = "Cargando";
                        await StatusLabel.FadeTo(1);
                        break;
                    case MediaPlayerStatus.Buffering:
                        //pause.IsEnabled = false;
                        //stop.IsEnabled = true;
                        StatusLabel.Text = "Almacenando";
                        await StatusLabel.FadeTo(1);
                        break;
                    case MediaPlayerStatus.Failed:
                        //pause.IsEnabled = false;
                        //stop.IsEnabled = false;
                        StatusLabel.Text = "Fallo";
                        await StatusLabel.FadeTo(1);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            });
        }

	    
	}

}