using IBook.Models;
using IBook.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
<<<<<<< HEAD
using System.IO;
=======
>>>>>>> 984b6d526975cac5c6e8334dd2f3039eb56a09b3
using System.Text;
using System.Windows.Input;
using IBook.Models;
using IBook.Repository;
using IBook.Services;
using Xamarin.Forms;

namespace IBook.ViewModels
{
<<<<<<< HEAD
    class HomeViewModel : INotifyPropertyChanged
    {
        public HomeViewModel()
        {
            bookRepository = new BookRepository();
            GetBookList();
        }
        public async void GetBookList()
        {
            BookList = new ObservableCollection<Book>(await bookRepository.ListAll());
            foreach (Book item in BookList)
            {
                object str = item.Hinh;
                item.Hinh = Xamarin.Forms.ImageSource.FromStream(
                () => new MemoryStream(Convert.FromBase64String(str.ToString())));
            }
=======
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
>>>>>>> 984b6d526975cac5c6e8334dd2f3039eb56a09b3
            RaisePropertyChanged("BookList");
        }
        private BookRepository bookRepository { get; set; }
        public ObservableCollection<Book> BookList { get; set; }
<<<<<<< HEAD
=======
        public  Book ChosenBook { get; set; }
        public ICommand ToDetailCommand { get; set; }


>>>>>>> 984b6d526975cac5c6e8334dd2f3039eb56a09b3
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string PropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
    }
}
