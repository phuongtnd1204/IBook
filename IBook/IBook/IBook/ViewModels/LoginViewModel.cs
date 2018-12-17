using IBook.Models;
using IBook.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace IBook.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public UserRepository userRepository;
        public ICommand SignInCommand { get; private set; }
        public ICommand SignUpCommand { get; private set; }
        private string _tenDangNhap;
        public string TenDangNhap
        {
            get { return _tenDangNhap; }
            set
            {
                _tenDangNhap = value;
                RaisePropertyChanged("TenDangNhap");
                ((Command)SignInCommand).ChangeCanExecute();
            }
        }
        public bool CanExe()
        {
            if (string.IsNullOrEmpty(_tenDangNhap) || string.IsNullOrEmpty(_matKhau))
                return false;
            else
                return true;
        }
        private string _matKhau;
        public string MatKhau
        {
            get { return _matKhau; }
            set
            {
                _matKhau = value;
                RaisePropertyChanged("MatKhau");
                ((Command)SignInCommand).ChangeCanExecute();
            }
        }
        public LoginViewModel()
        {
            userRepository = new UserRepository();
            SignInCommand = new Command(SignIn, CanExe);
            SignUpCommand = new Command(SignUp);
        }
        private void SignIn()
        {
            switch (userRepository.SignIn(_tenDangNhap, _matKhau))
            {
                case 0:
                    {
                        Application.Current.MainPage.DisplayAlert("Thông báo", "Thông tin đăng nhập sai", "OK");
                        break;
                    }
                case 1:
                    {
                        Application.Current.MainPage.Navigation.PushAsync(new View.PageManagement());
                        break;
                    }
                case 2:
                    {
                        Application.Current.MainPage.Navigation.PushAsync(new View.PageHome());
                        break;
                    }
            }
        }
        private void SignUp()
        {
            Application.Current.MainPage.Navigation.PushAsync(new View.PageSignUp());
        }

        private void RaisePropertyChanged(string PropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
    }
}
