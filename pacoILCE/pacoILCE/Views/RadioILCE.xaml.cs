using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pacoILCE.ViewModels;
using Plugin.MediaManager;
using Plugin.MediaManager.Abstractions.Enums;
using Plugin.MediaManager.Abstractions.EventArguments;
using Plugin.MediaManager.Abstractions.Implementations;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace pacoILCE.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RadioILCE : ContentPage
	{
	    private string audioUrl = "http://201.159.130.34:8080/radioilce.mp3";

        public RadioILCE ()
		{
			InitializeComponent ();
            BindingContext = new RadioILCEViewModel();
            //CrossMediaManager.Current.PlayingChanged += (sender, args) => progress.Progress = args.Progress;
            //CrossMediaManager.Current.Play(audioUrl, MediaFileType.Video);
            //MyVideoView.Source = audioUrl;
            //PlayButto.Clicked += (sender, args) => CrossMediaManager.Current.PlaybackController.Play();
            //StopButto.Clicked += (sender, args) => CrossMediaManager.Current.PlaybackController.Stop();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            CrossMediaManager.Current.Stop();
            CrossMediaManager.Current.StatusChanged += CurrentOnStatusChanged;
            CrossMediaManager.Current.PlayingChanged += OnPlayingChanged;
            CrossMediaManager.Current.MediaFileChanged += OnMediaFileChanged;
            //MyAudioView.Source = audioUrl;
            PlayButto.Clicked += PlayButton_OnClicked;
            StopButto.Clicked += StopButton_OnClicked;

            PlayButto.IsEnabled = true;
            StopButto.IsEnabled = false;
            PlayButto.IsVisible = true;
            StopButto.IsVisible = false;
            StatusLabe.Text = "";
        }

        protected override void OnDisappearing()
        {
            CrossMediaManager.Current.Stop();
            PlayButto.Clicked -= PlayButton_OnClicked;
            StopButto.Clicked -= StopButton_OnClicked;
            CrossMediaManager.Current.StatusChanged -= CurrentOnStatusChanged;
            CrossMediaManager.Current.PlayingChanged -= OnPlayingChanged;
            CrossMediaManager.Current.MediaFileChanged -= OnMediaFileChanged;
            //PlayButton.IsEnabled = true;
            //StopButton.IsEnabled = false;
            //PlayButton.IsVisible = true;
            //StopButton.IsVisible = false;
            //StatusLabel.Text = "";
            base.OnDisappearing();
        }

        private void OnMediaFileChanged(object sender, MediaFileChangedEventArgs e)
        {
            var artist = e.File.Metadata.Artist;
            var title = e.File.Metadata.Title;
            //Informacion.Text = title;
            //    artist + "-" + e.File.Metadata.Genre + "-" + e.File.Metadata.Title
            //+ "-" + e.File.Metadata.Genre
            //+ "-" + e.File.Metadata.Title
            //+ "-" + e.File.Metadata.Album
            //+ "-" + e.File.Metadata.AlbumArtUri
            //+ "-" + e.File.Metadata.AlbumArtist
            //+ "-" + e.File.Metadata.ArtUri
            //+ "-" + e.File.Metadata.Artist
            //+ "-" + e.File.Metadata.Author
            //+ "-" + e.File.Metadata.Compilation
            //+ "-" + e.File.Metadata.Composer
            //+ "-" + e.File.Metadata.DisplayDescription
            //+ "-" + e.File.Metadata.Writer
            //+ "-" + e.File.Metadata.DisplaySubtitle
            //+ "-" + e.File.Metadata.DisplayTitle
            //   + "-" + e.File.Metadata.MediaId
            //+ "-" + e.File.Metadata.MediaUri
            //+ "-" + e.File.Metadata.Rating
            //+ "-" + e.File.Metadata.Writer;

        }

        private void OnPlayingChanged(object sender, PlayingChangedEventArgs e)
        {
            //Int32 segundosTotales = (Int32)e.Position.TotalSeconds;
            Int32 segundosTotales = (Int32)e.Position.TotalSeconds / 1000 % 60;
            Int32 minutosTotales = (Int32)e.Position.TotalMinutes / 1000 % 60;
            Int32 horasTotales = (Int32)e.Position.TotalHours / 1000;

            string segundosTotalesCadena = "";
            string minutosTotalesCadena = "";
            string horasTotalesCadena = "";

            if (segundosTotales.ToString().Length > 1)
                segundosTotalesCadena = segundosTotales.ToString();
            else
                segundosTotalesCadena = "0" + segundosTotales.ToString();

            if (minutosTotales.ToString().Length > 1)
                minutosTotalesCadena = minutosTotales.ToString();
            else
                minutosTotalesCadena = "0" + minutosTotales.ToString();

            if (horasTotales.ToString().Length > 1)
                horasTotalesCadena = horasTotales.ToString();
            else
                horasTotalesCadena = "0" + horasTotales.ToString();

            horasTotalesCadena = horasTotalesCadena + ":" + minutosTotalesCadena + ":" + segundosTotalesCadena;

            Device.BeginInvokeOnMainThread(() =>
            {
                Posicio.Text = "" + horasTotalesCadena;
                //Posicio.Text = string.Format("{0}:{1:00}:{2:00}", (int)e.Position.TotalHours, e.Position.Minutes, e.Position.Seconds);
                //Posicio.Text = "" + (int)e.Position.TotalHours + "/" + (int)e.Position.TotalMinutes + "/" + (int)e.Position.TotalSeconds + "\n" 
                //               + (int)e.Position.Hours + "/" + (int)e.Position.Minutes + "/" + (int)e.Position.Seconds + "\n"
                //               + horasTotales + "/" + minutosTotales + "/" + segundosTotales + "\n"
                //               + (int)e.Position.Ticks;
                
            });
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
                //reconfigure layout
                if (width > height)
                {
                    outerStac.Orientation = StackOrientation.Horizontal;
                }
                else
                {
                    outerStac.Orientation = StackOrientation.Vertical;
                }
            }
        }

        private async void PlayButton_OnClicked(object sender, EventArgs e)
        {
            //MyAudioView.Source = audioUrl;
            //await CrossMediaManager.Current.Play(audioUrl, MediaFileType.Audio);
            await CrossMediaManager.Current.Play(audioUrl, MediaFileType.Video);
            //await CrossMediaManager.Current.Play(audioUrl);
            //await CrossMediaManager.Current.Play();
            //await CrossMediaManager.Current.AudioPlayer.Play();
            PlayButto.IsEnabled = false;
            StopButto.IsEnabled = true;
            PlayButto.IsVisible = false;
            StopButto.IsVisible = true;
        }

        private async void StopButton_OnClicked(object sender, EventArgs e)
        {
            await CrossMediaManager.Current.Stop();
            PlayButto.IsEnabled = true;
            StopButto.IsEnabled = false;
            PlayButto.IsVisible = true;
            StopButto.IsVisible = false;
        }

        private void CurrentOnStatusChanged(object sender, StatusChangedEventArgs statusChangedEventArgs)
        {
            //Debug.WriteLine($"MediaManager Status: {statusChangedEventArgs.Status}");
            Device.BeginInvokeOnMainThread(async () =>
            {
                var status = statusChangedEventArgs.Status;
                switch (status)
                {
                    case MediaPlayerStatus.Stopped:
                        //pause.IsEnabled = false;
                        //stop.IsEnabled = false;
                        StatusLabe.Text = "Detenido";
                        await StatusLabe.FadeTo(1);
                        break;
                    case MediaPlayerStatus.Paused:
                        //pause.IsEnabled = true;
                        //stop.IsEnabled = true;
                        StatusLabe.Text = "Pausado";
                        await StatusLabe.FadeTo(1);
                        break;
                    case MediaPlayerStatus.Playing:
                        //pause.IsEnabled = true;
                        //stop.IsEnabled = true;
                        await StatusLabe.FadeTo(0);
                        break;
                    case MediaPlayerStatus.Loading:
                        //pause.IsEnabled = false;
                        //stop.IsEnabled = false;
                        StatusLabe.Text = "Cargando";
                        await StatusLabe.FadeTo(1);
                        break;
                    case MediaPlayerStatus.Buffering:
                        //pause.IsEnabled = false;
                        //stop.IsEnabled = true;
                        StatusLabe.Text = "Almacenando";
                        await StatusLabe.FadeTo(1);
                        break;
                    case MediaPlayerStatus.Failed:
                        PlayButto.IsEnabled = true;
                        PlayButto.IsVisible = true;
                        StopButto.IsEnabled = false;
                        StopButto.IsVisible = false;
                        StatusLabe.Text = "Fallo";
                        await StatusLabe.FadeTo(1);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            });
        }

    }
}