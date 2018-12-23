using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using IBook.Models;
using Xamarin.Forms;

namespace IBook.ViewModels
{
    public class UserAccountViewModel
    {
        public UserAccountViewModel()
        {
            ToDetailCommand = new Command(ToDetail);
            LogOutCommand = new Command(LogOut);
            LoadData();
        }

        private void LoadData()
        {
            HoVaTen = App.mainUser.TenNguoiDung;
            SoDienThoai = App.mainUser.SoDienThoai;
            TenDangNhap = App.mainUser.TenDangNhap;
        }

        public ICommand ToDetailCommand { get; private set; }
        public ICommand LogOutCommand { get; private set; }

        public string HoVaTen { get; set; }
        public string SoDienThoai { get; set; }
        public string TenDangNhap { get; set; }
        private void ToDetail()
        {
            Application.Current.MainPage.Navigation.PushAsync(new View.PageUserAccountDetail());
        }

        private void LogOut()
        {
            App.listChon = null;
            App.mainUser = null;
            Application.Current.MainPage.Navigation.PushAsync(new View.PageLogin());
        }

    }
}
