using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace IBook.ViewModels
{
    public class ManagementViewModel
    {
        public string TenNguoiDung { get; set; }
        public ICommand ToUserCommand { get; private set; }
        public ICommand ToBookCommand { get; private set; }
        public ICommand ToAuthorCommand { get; private set; }
        public ICommand ToBookKindCommand { get; private set; }
        public ICommand ToLogOutCommand { get; private set; }
        public ManagementViewModel()
        {
            ShowName();
            ToUserCommand = new Command(ToUser);
            ToBookCommand = new Command(ToBook);
            ToAuthorCommand = new Command(ToAuthor);
            ToBookKindCommand = new Command(ToBookKind);
            ToLogOutCommand = new Command(LogOut);
        }

        private  void ShowName()
        {
            TenNguoiDung = "Xin chào " + App.mainUser.TenNguoiDung;
        }

        private void ToUser()
        {            
            Application.Current.MainPage.Navigation.PushAsync(new View.PageAccountManagement());
        }
        private void ToBook()
        {
            Application.Current.MainPage.Navigation.PushAsync(new View.PageBookManagement());
        }
        private void ToAuthor()
        {
            Application.Current.MainPage.Navigation.PushAsync(new View.PageAuthorManagement());
        }
        private void ToBookKind()
        {
            Application.Current.MainPage.Navigation.PushAsync(new View.PageTypeManagement());
        }
        private void LogOut()
        {
            App.mainUser = null;
            Application.Current.MainPage.Navigation.PushAsync(new View.PageLogin());
        }


    }
}
