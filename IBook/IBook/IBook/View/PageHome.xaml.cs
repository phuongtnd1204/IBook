using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IBook.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IBook.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PageHome : ContentPage
	{
		public PageHome ()
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);
		}
        protected override bool OnBackButtonPressed()
        {
            Android.OS.Process.KillProcess(Android.OS.Process.MyPid());
            return true;
        }

        private void Selected(object sender, SelectedItemChangedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null;
        }
    }
}