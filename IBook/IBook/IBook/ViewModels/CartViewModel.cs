using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using IBook.Models;
using IBook.Repository;
using Xamarin.Forms;

namespace IBook.ViewModels
{
    public class CartViewModel : INotifyPropertyChanged
    {
        private BookRepository bookRepository { get; set; }
        public  ObservableCollection<Book> BooksToShow { get; set; }
        public string TongTien { get; set; }
        public  string DiaChi { get; set; }
        public  ICommand ConfirmCommand { get; set; }
        public ICommand DeleteBookCommand { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand SubCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public  Book ChosenBook { get; set; }
        public CartViewModel()
        {
            if (App.listChon != null)
            {
                bookRepository = new BookRepository();
                ConfirmCommand = new Command(Confirm);
                DeleteBookCommand = new Command(DeleteBook, CanExe);
                AddCommand = new Command(Add);
                SubCommand = new Command(Sub);
                UpdateCommand = new Command(Update);
                LoadData();
            }

        }

        private void Update()
        {
            TinhTong();
        }

        private bool CanExe()
        {
            if (ChosenBook == null)
                return true;
            else
            {
                return false;
            }
        }

        private void Add()
        {
            ChosenBook.SoLuong++;
            TinhTong();
            //RaisePropertyChanged(TongTien);
        }
        private void Sub()
        {
            ChosenBook.SoLuong--;
            TinhTong();
            //RaisePropertyChanged(TongTien);
        }
        private void DeleteBook()
        {
            if (ChosenBook == null)
            {
                App.Current.MainPage.DisplayAlert("Thông báo", "Chưa có sách nào được chọn", "OK");
            }
            else
            {
                App.listChon.Remove(ChosenBook.MaSach.ToString());
                LoadData();
            }
        }
        private void Confirm()
        {

        }

        private async void LoadData()
        {
            BooksToShow = new ObservableCollection<Book>(await bookRepository.ListSomeBook());
            TinhTong();
            RaisePropertyChanged("BooksToShow");
            RaisePropertyChanged("TongTien");
        }

        public void TinhTong()
        {
            int TongValue = 0;
            for (int i = 0; i < BooksToShow.Count; i++)
            {
                TongValue += (BooksToShow[i].GiaBan * BooksToShow[i].SoLuong);
            }
            TongTien = TongValue.ToString();
            RaisePropertyChanged(TongTien);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string PropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
    }
}
