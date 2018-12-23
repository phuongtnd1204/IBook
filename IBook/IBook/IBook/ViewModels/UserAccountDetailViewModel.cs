using IBook.Models;
using System;
using System.Collections.Generic;
<<<<<<< HEAD
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
=======
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using IBook.Models;
using IBook.Services;
>>>>>>> 1ba767c71696e104071086c7b26aaec07964a31b
using Xamarin.Forms;

namespace IBook.ViewModels
{
    public class UserAccountDetailViewModel : INotifyPropertyChanged
    {
<<<<<<< HEAD
        public ICommand ToChangePasswordCommand { get; private set; }
        private bool line;
        private ImageSource image;
        public UserAccountDetailViewModel()
        {
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
=======
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
           
>>>>>>> 1ba767c71696e104071086c7b26aaec07964a31b
        }
    }
}
