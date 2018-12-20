using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace IBook.ViewModels
{
    public class UserAccountViewModel
    {
        public UserAccountViewModel()
        {
            ToDetailCommand = new Command(ToDetail);
        }

        public ICommand ToDetailCommand { get; private set; }
        private void ToDetail()
        {
            Application.Current.MainPage.Navigation.PushAsync(new View.PageUserAccountDetail());
        }

    }
}
