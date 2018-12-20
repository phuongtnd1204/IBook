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
        public LoginViewModel()
        {
            userRepository = new UserRepository();
            SignInCommand = new Command(SignIn, CanExe);
            SignUpCommand = new Command(SignUp);
        }

        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string PropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
        #endregion

        #region ICommand
        public ICommand SignInCommand { get; private set; }
        public ICommand SignUpCommand { get; private set; }
        #endregion

        #region Khai bao thuoc tinh
        public UserRepository userRepository;
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
        #endregion

        #region Func
        public bool CanExe()
        {
            if (string.IsNullOrEmpty(_tenDangNhap) || string.IsNullOrEmpty(_matKhau))
                return false;
            else
                return true;
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
                        Application.Current.MainPage.Navigation.PushAsync(new View.PageUserHome());
                        break;
                    }

                default:
                    {
                        Application.Current.MainPage.DisplayAlert("Thông báo", "Lỗi kết nối", "OK");
                        break;
                    }

            }
        }
        private void SignUp()
        {
            Application.Current.MainPage.Navigation.PushAsync(new View.PageSignUp());
        }
        #endregion


    }
}
