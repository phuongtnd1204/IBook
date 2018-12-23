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
	public partial class PageHome : ContentPage
	{
		public PageHome ()
		{
			InitializeComponent ();
		}
        protected override bool OnBackButtonPressed()
        {
            return true;
        }
    }
}