using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using IBook.Models;
using IBook.Repository;
using IBook.Services;
using Xamarin.Forms;

namespace IBook.ViewModels
{
    public class HomeViewModel : INotifyPropertyChanged
    {

        public HomeViewModel()
        {
            bookRepository = new BookRepository();
            ChosenBook = new Book();
            ToDetailCommand=new Command(ToDetail);
            GetBookList();
        }
        private void ToDetail()
        {
            App.Current.Properties["ID"] = ChosenBook;
            App.Current.MainPage.Navigation.PushAsync(new View.PageBookDetail());
        }
        public async void GetBookList()
        {
            BookList = new ObservableCollection<Book>( await bookRepository.ListAll());
            RaisePropertyChanged("BookList");
        }
        private BookRepository bookRepository { get; set; }
        public ObservableCollection<Book> BookList { get; set; }
        public  Book ChosenBook { get; set; }
        public ICommand ToDetailCommand { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string PropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
    }
}
