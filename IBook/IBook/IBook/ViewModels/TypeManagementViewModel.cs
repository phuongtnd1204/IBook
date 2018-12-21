using IBook.Models;
using IBook.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace IBook.ViewModels
{
    public class TypeManagementViewModel : INotifyPropertyChanged
    {
        public TypeManagementViewModel()
        {
            BookKindRepository = new BookKindRepository();
            GetTypeList();
        }
        public async void GetTypeList()
        {
            BookKindList = new ObservableCollection<BookKind>(await BookKindRepository.ListAll());
            RaisePropertyChanged("BookKindList");
        }
        private BookKindRepository BookKindRepository { get; set; }
        public ObservableCollection<BookKind> BookKindList { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string PropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
    }
}
