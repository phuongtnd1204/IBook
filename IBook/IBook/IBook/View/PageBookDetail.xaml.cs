using IBook.Models;
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
	public partial class PageBookDetail : ContentPage
	{
		public PageBookDetail(Book book)
		{
			InitializeComponent ();
            this.BindingContext = new BookDetailViewMode(book);
            NavigationPage.SetHasNavigationBar(this, false);
        }
	}
}