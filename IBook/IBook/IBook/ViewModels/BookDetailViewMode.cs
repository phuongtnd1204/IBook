using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using IBook.Models;
using IBook.Repository;
using IBook.Services;
using Xamarin.Forms;

namespace IBook.ViewModels
{
    public class BookDetailViewMode : INotifyPropertyChanged

    {
        //private Service service { get; set; }
        public BookRepository BookRepository { get; set; }
        public  AuthorRepository authorRepository { get; set; }
        public BookKindRepository BookKindRepository { get; set; }
        public  Author  author { get; set; }
        public BookKind bookKind { get; set; }
        public  ICommand AddToCart { get; set; }
        public Book _book { get; set; }
        public BookDetailViewMode()
        {

            BookRepository = new BookRepository();
            author= new Author();
            bookKind=new BookKind();
            authorRepository= new AuthorRepository();
            BookKindRepository = new BookKindRepository();
            _book = new Book();
            //service = new Service();
            Load();
            AddToCart = new Command(Add);


        }
        private async void Load()
        {
            _book = (Book)App.Current.Properties["ID"];
            author =  authorRepository.SelectById(int.Parse(_book.TacGia)).Result;
            bookKind = BookKindRepository.SelectById(int.Parse(_book.TheLoai));
            
        }

        private void Add()
        {
            if (!App.listChon.Contains(_book.MaSach.ToString()))
            {
                App.listChon.Add(_book.MaSach.ToString());
                App.Current.MainPage.DisplayAlert("Thông báo", "Thêm thành công", "OK");
                App.Current.MainPage.Navigation.PushAsync(new View.PageUserHome());
            }
            else
            {
                App.Current.MainPage.DisplayAlert("Thông báo", "Bạn đã thêm vào giỏ hàng", "OK");
            }

        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string PropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        public string TenTacGia { get; set; }
        public string TenTheLoai { get; set; }
    }
}
