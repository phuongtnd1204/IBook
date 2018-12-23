using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace IBook.ViewModels
{
    public class ManagementViewModel
    {
        public ICommand ToUserCommand { get; private set; }
        public ICommand ToBookCommand { get; private set; }
        public ICommand ToAuthorCommand { get; private set; }
        public ICommand ToBookKindCommand { get; private set; }
        public ICommand ToLogOutCommand { get; private set; }
        public ICommand ToReportCommand { get; private set; }
        public ManagementViewModel()
        {
            ToUserCommand = new Command(ToUser);
            ToBookCommand = new Command(ToBook);
            ToAuthorCommand = new Command(ToAuthor);
            ToBookKindCommand = new Command(ToBookKind);
            ToLogOutCommand = new Command(LogOut);
            ToReportCommand = new Command(ToReport);
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
            Application.Current.Properties["ID"] = "";
            Application.Current.MainPage.Navigation.PushAsync(new View.PageLogin());
        }
        private void ToReport()
        {
            Application.Current.MainPage.Navigation.PushAsync(new View.PageReport());
        }

    }
}
