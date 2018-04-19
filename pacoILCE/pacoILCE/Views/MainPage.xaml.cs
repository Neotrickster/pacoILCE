using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pacoILCE.Views;
using Xamarin.Forms;

namespace pacoILCE
{
	public partial class MainPage : MasterDetailPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

	    private void BtnAcercaDe_OnClicked(object sender, EventArgs e)
	    {
	        Detail = new AcercaDe();
	    }

	    private void BtnTwitter_OnClicked(object sender, EventArgs e)
	    {
	        Detail = new Twitter();
        }

	    private void BtnRadioIlce_OnClicked(object sender, EventArgs e)
	    {
	        Detail = new RadioILCE();
        }

	    private void BtnSummaSaberes_OnClicked(object sender, EventArgs e)
	    {
	        Detail = new SummaSaberes();
        }

	    private void BtnCanalIberoamericano_OnClicked(object sender, EventArgs e)
	    {
	        Detail = new CanalIberoamericano();
        }
	}
}
