using IBook.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IBook.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PageCart : ContentPage
	{
		public PageCart ()
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);
		}
        protected override bool OnBackButtonPressed()
        {
            Android.OS.Process.KillProcess(Android.OS.Process.MyPid());
            return true;
        }

        protected async override void OnAppearing()
        {
            Reload();
            base.OnAppearing();
        }
        async void Reload()
        {
            BindingContext = new CartViewModel();
        }

        private void Selected(object sender, SelectedItemChangedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null;
        }
    }
}