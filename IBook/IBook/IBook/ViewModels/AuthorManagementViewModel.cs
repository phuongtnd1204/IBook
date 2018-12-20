using IBook.Models;
using IBook.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace IBook.ViewModels
{
    public class AuthorManagementViewModel
    {
        public AuthorManagementViewModel()
        {
            authorRepository = new AuthorRepository();
            AuthorList = new ObservableCollection<Author>(authorRepository.ListAll());
        }
        private AuthorRepository authorRepository { get; set; }
        public ObservableCollection<Author> AuthorList { get; set; }
    }
}
