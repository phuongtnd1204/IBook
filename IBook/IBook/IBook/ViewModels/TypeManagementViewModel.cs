using IBook.Models;
using IBook.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace IBook.ViewModels
{
    public class TypeManagementViewModel
    {
        public TypeManagementViewModel()
        {
            bookKindRepository = new BookKindRepository();
            BookKindList = new ObservableCollection<BookKind>(bookKindRepository.ListAll());
        }
        private BookKindRepository bookKindRepository { get; set; }
        public ObservableCollection<BookKind> BookKindList { get; set; }
    }
}
