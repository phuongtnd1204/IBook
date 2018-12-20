using IBook.Models;
using IBook.Repository;
using IBook.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace IBook.ViewModels
{
    public class SignUpViewModel : INotifyPropertyChanged
    {
        public SignUpViewModel()
        {
            user = new User();
            userRepository = new UserRepository();
            SignUpCommand = new Command(SignUp,CanExe);
        }

        #region Khai bao
        private UserRepository userRepository { get; set; }
        private User user { get; set; }
        public string TenDangNhap
        {
            get { return user.TenDangNhap; }
            set
            {
                user.TenDangNhap = value;
                RaisePropertyChanged("TenDangNhap");
                ((Command)SignUpCommand).ChangeCanExecute();
            }
        }
        public string MatKhau
        {
            get { return user.MatKhau; }
            set
            {
                user.MatKhau = value;
                RaisePropertyChanged("MatKhau");
                ((Command)SignUpCommand).ChangeCanExecute();
            }
        }
        public string TenNguoiDung
        {
            get { return user.TenNguoiDung; }
            set
            {
                user.TenNguoiDung = value;
                RaisePropertyChanged("TenNguoiDung");
                ((Command)SignUpCommand).ChangeCanExecute();
            }
        }
        public string SoDienThoai
        {
            get { return user.SoDienThoai; }
            set
            {
                user.SoDienThoai = value;
                RaisePropertyChanged("SoDienThoai");
                ((Command)SignUpCommand).ChangeCanExecute();
            }
        }

        #endregion

        #region ICommand
        public ICommand SignUpCommand { get; private set; }
        #endregion

        #region Func
        public void SignUp()
        {
            if(userRepository.SignUp(user))
            {
                Application.Current.MainPage.DisplayAlert("Thông báo", "Đăng ký thành công", "OK");
                Application.Current.MainPage.Navigation.PopAsync();
            }
            else
            {
                Application.Current.MainPage.DisplayAlert("Thông báo", "Đăng ký thất bại", "OK");
            }
            
        }
        public bool CanExe()
        {
            if (string.IsNullOrEmpty(TenDangNhap) || string.IsNullOrEmpty(TenNguoiDung) ||
                string.IsNullOrEmpty(MatKhau) || string.IsNullOrEmpty(SoDienThoai))
                return false;
            else
                return true;
        }
        #endregion

        #region PropertyChanged
        private void RaisePropertyChanged(string PropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
    }
}
