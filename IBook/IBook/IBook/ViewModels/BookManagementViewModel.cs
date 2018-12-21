using IBook.Models;
using IBook.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace IBook.ViewModels
{
    public class BookManagementViewModel : INotifyPropertyChanged
    {
        public BookManagementViewModel()
        {
            bookRepository = new BookRepository();
            GetBookList();
        }
        public async void GetBookList()
        {
            BookList = new ObservableCollection<Book>(await bookRepository.ListAll());
            RaisePropertyChanged("BookList");
        }
        private BookRepository bookRepository { get; set; }
        public ObservableCollection<Book> BookList { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string PropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
    }
}
