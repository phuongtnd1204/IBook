using IBook.Models;
using IBook.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace IBook.ViewModels
{
    public class AccountManagementViewModel : INotifyPropertyChanged
    {
        public AccountManagementViewModel()
        {
            userRepository = new UserRepository();
            GetUserList();
        }
        public async void GetUserList()
        {
            UserList = new ObservableCollection<User>(await userRepository.ListAll());
            RaisePropertyChanged("UserList");
        }
        private UserRepository userRepository { get; set; }
        public ObservableCollection<User> UserList { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string PropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
    }
}
