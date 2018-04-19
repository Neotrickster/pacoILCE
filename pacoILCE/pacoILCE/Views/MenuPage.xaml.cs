using System;
using System.Collections.Generic;
using pacoILCE.Models;
using pacoILCE.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace pacoILCE.Views
{
	public partial class MenuPage : ContentPage
	{
	    RootPage root;
	    List<HomeMenuItem> menuItems;
	    public MenuPage(RootPage root)
	    {

	        this.root = root;
	        InitializeComponent();
	        
            /*BaseViewModel toma precedencia en caso de que no exista un ViewModel para la página*/
	        BindingContext = new BaseViewModel
	        {
	            Title = "ILCE",
	            Subtitle = "Ilce",
	            Icon = "slideout.png"
	        };

	        ListViewMenu.ItemsSource = menuItems = new List<HomeMenuItem>
	        {
	            new HomeMenuItem { Title = "Acerca de", MenuType = MenuType.AcercaDe, Icon ="ilceicono.png" },
	            new HomeMenuItem { Title = "Twitter", MenuType = MenuType.Twitter, Icon = "twitter.png" },
	            //new HomeMenuItem { Title = "Facebook", MenuType = MenuType.Facebook, Icon = "facebook.png" },
	            new HomeMenuItem { Title = "Radio ILCE", MenuType = MenuType.RadioIlce, Icon = "radioilce.png" },
	            new HomeMenuItem { Title = "Summa Saberes", MenuType = MenuType.SummaSaberes, Icon = "canal15.png" },
	            new HomeMenuItem { Title = "Canal Iberoamericano", MenuType = MenuType.CanalIberoamericano, Icon = "canaliberoamericano.png"}
	        };

	        ListViewMenu.SelectedItem = menuItems[0];

	        ListViewMenu.ItemSelected += async (sender, e) =>
	        {
	            if (ListViewMenu.SelectedItem == null)
	                return;

	            await this.root.NavigateAsync((int)((HomeMenuItem)e.SelectedItem).MenuType);

	        };
	    }
    }
}