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
	public partial class PageManagement : ContentPage
	{
		public PageManagement ()
		{
			InitializeComponent ();
		}
        protected override bool OnBackButtonPressed()
        {
            return true;
        }
    }
<<<<<<< HEAD
=======

>>>>>>> 1ba767c71696e104071086c7b26aaec07964a31b
}