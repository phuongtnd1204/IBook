using IBook.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using IBook.Services;
using Xamarin.Forms;
using IBook.Repository;

namespace IBook.ViewModels
{
    public class UserAccountDetailViewModel : INotifyPropertyChanged
    {
        public ICommand ToChangePasswordCommand { get; private set; }
        private bool line;
        string presentpassword;
        string newpassword;
        string repeatpassword;
        private ImageSource image;
        public UserAccountDetailViewModel()
        {
            user = new User();
            user = App.mainUser;
            userRepository = new UserRepository();
            UpdateCommand = new Command(Update);
            ToChangePasswordCommand = new Command(ToChangePassword);
            image= "round_keyboard_arrow_down_black_18dp.png";

        }
        private void ToChangePassword()
        {
            if (LineVisible == false)
            {
                LineVisible = true;
                PresentPasswordVisible = true;
                NewPasswordVisible = true;
                RepeatPasswordVisible = true;
                ImageChangePassword = "round_keyboard_arrow_up_black_18dp.png";
            }
            else
            {
                LineVisible = false;
                PresentPasswordVisible = false;
                NewPasswordVisible = false;
                RepeatPasswordVisible = false;
                ImageChangePassword = "round_keyboard_arrow_down_black_18dp.png";
            }
        }
        public string PresentPassword
        {
            get { return presentpassword; }
            set
            {
                presentpassword = value;
                RaisePropertyChanged("PresentPassword");
            }
        }
        public string NewPassword
        {
            get { return newpassword; }
            set
            {
                newpassword = value;
                RaisePropertyChanged("NewPassword");
            }
        }
        public string RepeatPassword
        {
            get { return repeatpassword; }
            set
            {
                repeatpassword = value;
                RaisePropertyChanged("RepeatPassword");
            }
        }
        public bool LineVisible
        {
            get { return line; }
            set
            {
                line = value;
                RaisePropertyChanged("LineVisible");
            }
        }
        public bool PresentPasswordVisible
        {
            get { return line; }
            set
            {
                line = value;
                RaisePropertyChanged("PresentPasswordVisible");
            }
        }
        public bool NewPasswordVisible
        {
            get { return line; }
            set
            {
                line = value;
                RaisePropertyChanged("NewPasswordVisible");
            }
        }
        public bool RepeatPasswordVisible
        {
            get { return line; }
            set
            {
                line = value;
                RaisePropertyChanged("RepeatPasswordVisible");
            }
        }
        public ImageSource ImageChangePassword
        {
            get { return image; }
            set
            {
                image = value;
                RaisePropertyChanged("ImageChangePassword");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string PropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
        private UserRepository userRepository;
        public User user { get; set; }
        public ICommand UpdateCommand { get; private set; }

        private async void Update()
        {
            if (LineVisible == true)
            {
                if (NewPassword != RepeatPassword)
                {
                    App.Current.MainPage.DisplayAlert("Thông báo", "Nhập lại mật khẩu không đúng!", "OK");
                }
                else if (user.MatKhau == PresentPassword)
                {
                    user.MatKhau = NewPassword;
                    if (await userRepository.UpdateUser(user))
                    {
                        App.Current.MainPage.DisplayAlert("Thông báo", "Cập nhật thành công", "OK");
                        App.Current.MainPage.Navigation.PushAsync(new View.PageUserAccount());
                    }
                    else
                    {
                        App.Current.MainPage.DisplayAlert("Thông báo", "Cập nhật thất bại", "OK");
                    }
                }
                else
                {
                    App.Current.MainPage.DisplayAlert("Thông báo", "Mật khẩu sai!", "OK");
                }
            }
            else
            {
                if (await userRepository.UpdateUser(user))
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
}
