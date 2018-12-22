using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using IBook.Models;
using IBook.Services;
using Xamarin.Forms;

namespace IBook.ViewModels
{
    public class UserAccountDetailViewModel
    {
        private Service service;
        public User user { get; set; }
        public ICommand UpdateCommand { get; private set; }
        public UserAccountDetailViewModel()
        {
            user = new User();
            user = App.mainUser;
            service = new Service();
            UpdateCommand = new Command(Update);
        }

        private async void Update()
        {
            if (await service.UpdateUser(user))
            {
                App.Current.MainPage.DisplayAlert("Thông báo", "Cập nhật thành công", "OK");
                App.Current.MainPage.Navigation.PushAsync(new View.PageUserAccount());
            }
            else
            {
                App.Current.MainPage.DisplayAlert("Thông báo", "Cập nhật thất bại", "OK");
            }
           
        }
    }
}
