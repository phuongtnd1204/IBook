using IBook.Models;
using IBook.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Windows.Input;
using IBook.Services;
using Xamarin.Forms;

namespace IBook.ViewModels
{
    public class HomeViewModel : INotifyPropertyChanged
    {

        public HomeViewModel()
        {
            App.listChon = new List<Book>();
            bookRepository = new BookRepository();
            if (App.listBook == null)
            {
                GetBookList();
            }
            else BookList = App.listBook;
        }
        public async void GetBookList()
        {
            BookList = new ObservableCollection<Book>( await bookRepository.ListAll());
            foreach (Book item in BookList)
            {
                object str = item.Hinh;
                item.Hinh = Xamarin.Forms.ImageSource.FromStream(
                () => new MemoryStream(Convert.FromBase64String(str.ToString())));
            }
            App.listBook = BookList;
            RaisePropertyChanged("BookList");
        }
        private BookRepository bookRepository { get; set; }
        public ObservableCollection<Book> BookList { get; set; }
        private Book chosenBook;
        public  Book ChosenBook {
            get { return chosenBook; }
            set
            {
                chosenBook = value;
                RaisePropertyChanged("ChosenBook");
                if (ChosenBook != null)
                {
                    App.Current.MainPage.Navigation.PushAsync(new View.PageBookDetail(ChosenBook));
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string PropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
    }
}
