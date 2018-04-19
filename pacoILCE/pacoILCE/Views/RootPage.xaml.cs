using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using pacoILCE.Models;
using pacoILCE.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace pacoILCE.Views
{
	
	public partial class RootPage : MasterDetailPage //no encuentro donde agregué esta referencia por lo que usaré partial para solucionarlo
	{

	    Dictionary<int, NavigationPage> Pages { get; set; }

        public RootPage()
		{
			//InitializeComponent ();

		    Pages = new Dictionary<int, NavigationPage>();
		    Master = new MenuPage(this);
		    BindingContext = new BaseViewModel
		    {
		        Title = "ILCE",
		        Icon = "slideout.png"
		    };
		    //setup home page
		    Pages.Add((int)MenuType.AcercaDe, new NavigationPage(new AcercaDe()));
		    Detail = Pages[(int)MenuType.AcercaDe];

		    InvalidateMeasure();
        }

	    public async Task NavigateAsync(int id)
	    {

	        //if (Detail != null)
	        //{
	        //    if (Device.RuntimePlatform == Device.Android)
	        //        await Task.Delay(300);
	        //}

	        Page newPage;
	        if (!Pages.ContainsKey(id))
	        {

	            switch (id)
	            {
	                case (int)MenuType.AcercaDe:
	                    Pages.Add(id, new NavigationPage(new AcercaDe()));
	                    break;
	                case (int)MenuType.Twitter:
	                    Pages.Add(id, new NavigationPage(new Twitter()));
	                    break;
	                case (int)MenuType.RadioIlce:
	                    Pages.Add(id, new NavigationPage(new RadioILCE()));
	                    //Pages.Add(id, new NavigationPage(new AudioILCE()));
                        break;
	                case (int)MenuType.SummaSaberes:
	                    Pages.Add(id, new NavigationPage(new SummaSaberes()));
	                    break;
	                case (int)MenuType.CanalIberoamericano:
	                    Pages.Add(id, new NavigationPage(new CanalIberoamericano()));
	                    break;
	                //case (int)MenuType.Facebook:
	                //    Pages.Add(id, new NavigationPage(new Facebook()));
	                //    break;
	            }
	            //IsPresented = false;
            }

	        newPage = Pages[id];
	        if (newPage == null)
	            return;

	        Detail = newPage;
	        IsPresented = false;
        }
    }

    
}