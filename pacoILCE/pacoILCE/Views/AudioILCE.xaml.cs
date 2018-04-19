using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pacoILCE.ViewModels;
using Xamarians.MediaPlayer;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace pacoILCE.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AudioILCE : ContentPage
	{
	    private string audioUrl = "http://201.159.130.34:8080/radioilce.mp3";

        public AudioILCE ()
		{
			InitializeComponent();
		    BindingContext = new RadioILCEViewModel();

            
		    //PlayButton.Clicked += (sender, args) => audioPlayer.Play();
		    //StopButton.Clicked += (sender, args) => audioPlayer.Stop();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            audioPlayer.Source = audioUrl;
            PlayButton.Clicked += PlayButton_OnClicked;
            StopButton.Clicked += StopButton_OnClicked;

            PlayButton.IsEnabled = true;
            StopButton.IsEnabled = false;
            PlayButton.IsVisible = true;
            StopButton.IsVisible = false;
            StatusLabel.Text = "";
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            PlayButton.Clicked -= PlayButton_OnClicked;
            StopButton.Clicked -= StopButton_OnClicked;
        }

        private void PlayButton_OnClicked(object sender, EventArgs e)
        {
            audioPlayer.Play();
            PlayButton.IsEnabled = false;
            StopButton.IsEnabled = true;
            PlayButton.IsVisible = false;
            StopButton.IsVisible = true;
        }

        private void StopButton_OnClicked(object sender, EventArgs e)
        {
            audioPlayer.Stop();
            PlayButton.IsEnabled = true;
            StopButton.IsEnabled = false;
            PlayButton.IsVisible = true;
            StopButton.IsVisible = false;
        }

        //   private void OnMediaFileChanged(object sender, MediaFileChangedEventArgs e)
        //{
        //    var artist = e.File.Metadata.Artist;
        //    var title = e.File.Metadata.Title;
        //    //Informacion.Text = title;
        //    //    artist + "-" + e.File.Metadata.Genre + "-" + e.File.Metadata.Title
        //    //+ "-" + e.File.Metadata.Genre
        //    //+ "-" + e.File.Metadata.Title
        //    //+ "-" + e.File.Metadata.Album
        //    //+ "-" + e.File.Metadata.AlbumArtUri
        //    //+ "-" + e.File.Metadata.AlbumArtist
        //    //+ "-" + e.File.Metadata.ArtUri
        //    //+ "-" + e.File.Metadata.Artist
        //    //+ "-" + e.File.Metadata.Author
        //    //+ "-" + e.File.Metadata.Compilation
        //    //+ "-" + e.File.Metadata.Composer
        //    //+ "-" + e.File.Metadata.DisplayDescription
        //    //+ "-" + e.File.Metadata.Writer
        //    //+ "-" + e.File.Metadata.DisplaySubtitle
        //    //+ "-" + e.File.Metadata.DisplayTitle
        //    //   + "-" + e.File.Metadata.MediaId
        //    //+ "-" + e.File.Metadata.MediaUri
        //    //+ "-" + e.File.Metadata.Rating
        //    //+ "-" + e.File.Metadata.Writer;

        //}

        //   private void OnPlayingChanged(object sender, PlayingChangedEventArgs e)
        //   {
        //       //Int32 segundosTotales = (Int32)e.Position.TotalSeconds;
        //       Int32 segundosTotales = (Int32)e.Position.TotalSeconds % 60;
        //       Int32 minutosTotales = (Int32)e.Position.TotalMinutes % 60; ;
        //       Int32 horasTotales = (Int32)e.Position.TotalHours;

        //       string segundosTotalesCadena = "";
        //       string minutosTotalesCadena = "";
        //       string horasTotalesCadena = "";

        //       if (segundosTotales.ToString().Length > 1)
        //           segundosTotalesCadena = segundosTotales.ToString();
        //       else
        //           segundosTotalesCadena = "0" + segundosTotales.ToString();

        //       if (minutosTotales.ToString().Length > 1)
        //           minutosTotalesCadena = minutosTotales.ToString();
        //       else
        //           minutosTotalesCadena = "0" + minutosTotales.ToString();

        //       if (horasTotales.ToString().Length > 1)
        //           horasTotalesCadena = horasTotales.ToString();
        //       else
        //           horasTotalesCadena = "0" + horasTotales.ToString();

        //       horasTotalesCadena = horasTotalesCadena + ":" + minutosTotalesCadena + ":" + segundosTotalesCadena;

        //       Device.BeginInvokeOnMainThread(() =>
        //       {
        //           Posicion.Text = "" + horasTotalesCadena;
        //       });
        //   }



        //   //   private async void PlayStopButton_OnClicked(object sender, EventArgs e)
        //   //{
        //   //    if (PlayStopButton.Text == "Play")
        //   //    {
        //   //        await CrossMediaManager.Current.Play(videoUrl, MediaFileType.Video);
        //   //        PlayStopButton.Text = "Stop";
        //   //    }
        //   //    else if (PlayStopButton.Text == "Stop")
        //   //    {
        //   //        await CrossMediaManager.Current.Stop();
        //   //        PlayStopButton.Text = "Play";
        //   //    }
        //   //   }

        //   private double _width = 0;
        //   private double _height = 0;

        //   protected override void OnSizeAllocated(double width, double height)
        //   {
        //       base.OnSizeAllocated(width, height); //must be called
        //       if (this._width != width || this._height != height)
        //       {
        //           this._width = width;
        //           this._height = height;
        //           //reconfigure layout
        //           if (width > height)
        //           {
        //               outerStack.Orientation = StackOrientation.Horizontal;
        //           }
        //           else
        //           {
        //               outerStack.Orientation = StackOrientation.Vertical;
        //           }
        //       }
        //   }

        //   private void CurrentOnStatusChanged(object sender, StatusChangedEventArgs statusChangedEventArgs)
        //   {
        //       Device.BeginInvokeOnMainThread(async () =>
        //       {
        //           var status = statusChangedEventArgs.Status;
        //           switch (status)
        //           {
        //               case MediaPlayerStatus.Stopped:
        //                   //pause.IsEnabled = false;
        //                   //stop.IsEnabled = false;
        //                   StatusLabel.Text = "Detenido";
        //                   await StatusLabel.FadeTo(1);
        //                   break;
        //               case MediaPlayerStatus.Paused:
        //                   //pause.IsEnabled = true;
        //                   //stop.IsEnabled = true;
        //                   StatusLabel.Text = "Pausado";
        //                   await StatusLabel.FadeTo(1);
        //                   break;
        //               case MediaPlayerStatus.Playing:
        //                   //pause.IsEnabled = true;
        //                   //stop.IsEnabled = true;
        //                   await StatusLabel.FadeTo(0);
        //                   break;
        //               case MediaPlayerStatus.Loading:
        //                   //pause.IsEnabled = false;
        //                   //stop.IsEnabled = false;
        //                   StatusLabel.Text = "Cargando";
        //                   await StatusLabel.FadeTo(1);
        //                   break;
        //               case MediaPlayerStatus.Buffering:
        //                   //pause.IsEnabled = false;
        //                   //stop.IsEnabled = true;
        //                   StatusLabel.Text = "Almacenando";
        //                   await StatusLabel.FadeTo(1);
        //                   break;
        //               case MediaPlayerStatus.Failed:
        //                   PlayButton.IsEnabled = true;
        //                   PlayButton.IsVisible = true;
        //                   StopButton.IsEnabled = false;
        //                   StopButton.IsVisible = false;
        //                   StatusLabel.Text = "Fallo";
        //                   await StatusLabel.FadeTo(1);
        //                   break;
        //               default:
        //                   throw new ArgumentOutOfRangeException();
        //           }
        //       });
        //   }
    }
}