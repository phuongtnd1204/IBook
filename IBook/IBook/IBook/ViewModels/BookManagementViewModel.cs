using IBook.Models;
using IBook.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace IBook.ViewModels
{
    public class BookManagementViewModel
    {
        public BookManagementViewModel()
        {
            bookRepository = new BookRepository();
            BookList = new ObservableCollection<Book>(bookRepository.ListAll());
        }
        private BookRepository bookRepository { get; set; }
        public ObservableCollection<Book> BookList { get; set; }
    }
}
