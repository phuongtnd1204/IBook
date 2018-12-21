using IBook.Models;
using IBook.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace IBook.ViewModels
{
    public class AuthorManagementViewModel : INotifyPropertyChanged
    {
        public AuthorManagementViewModel()
        {
            AuthorRepository = new AuthorRepository();
            GetAuthorList();
        }
        public async void GetAuthorList()
        {
            AuthorList = new ObservableCollection<Author>(await AuthorRepository.ListAll());
            RaisePropertyChanged("AuthorList");
        }
        private AuthorRepository AuthorRepository { get; set; }
        public ObservableCollection<Author> AuthorList { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string PropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
    }
}
