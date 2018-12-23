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
        private Invoice invoice { get; set; }
        private InvoiceDetail InvoiceDetail { get; set; }
        private  InvoiceRepository invoiceRepository { get; set; }
        private InvoiceDetailRepository InvoiceDetailRepository { get; set; }
        private BookRepository bookRepository { get; set; }
        public  ObservableCollection<Book> BooksToShow { get; set; }
        private string _tongTien;
        public string TongTien
        {
            get { return _tongTien; }
            set
            {
                _tongTien = value;
                RaisePropertyChanged(TongTien);
            }
        }
        public  string DiaChi { get; set; }
        public  ICommand ConfirmCommand { get; set; }
        public ICommand DeleteBookCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public  Book ChosenBook { get; set; }
        public CartViewModel()
        {
            if (App.listChon != null)
            {
                invoice = new Invoice();
                InvoiceDetail = new InvoiceDetail();
                bookRepository = new BookRepository();
                ConfirmCommand = new Command(Confirm);
                DeleteBookCommand = new Command(DeleteBook, CanExe);
                UpdateCommand = new Command(Update);
                invoiceRepository = new InvoiceRepository();
                InvoiceDetailRepository = new InvoiceDetailRepository();
                ChosenBook = new Book();
                LoadData();
            }

        }

        private void Update()
        {
            TinhTong();
        }

        private bool CanExe()
        {
            if (ChosenBook != null)
                return true;
            else
            {
                return false;
            }
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
        private async void Confirm()
        {
            invoice.MaNguoiDung = App.mainUser.MaNguoiDung;
            invoice.TongTien = int.Parse(TongTien);
            invoice.DiaChi = DiaChi;
            invoice.NgayHoaDon = DateTime.Now;
            
            
            for (int i = 0; i < BooksToShow.Count; i++)
            {
                InvoiceDetail= new InvoiceDetail(){MaHoaDon = 1, DonGia = BooksToShow[i].GiaBan, MaSach = BooksToShow[i].MaSach, SoLuong = BooksToShow[i].SoLuong,ThanhTien = (BooksToShow[i].GiaBan * BooksToShow[i].SoLuong) };
                await InvoiceDetailRepository.Add(InvoiceDetail);
            }

            if (await invoiceRepository.Add(invoice))
            {
                App.Current.MainPage.DisplayAlert("Thông báo", "Đặt mua thành công", "OK");
                App.listChon.Clear();
                TongTien = "0";
                DiaChi = "";
                RaisePropertyChanged(DiaChi);
                LoadData();

            }

        }

        private async void LoadData()
        {
            if (App.listChon != null)
            {
                BooksToShow = new ObservableCollection<Book>(await bookRepository.ListSomeBook());
                TinhTong();
                RaisePropertyChanged("BooksToShow");
                RaisePropertyChanged("TongTien");
            }
            else
            {
                BooksToShow = null;
            }

        }

        public void TinhTong()
        {
            int TongValue = 0;
            for (int i = 0; i < BooksToShow.Count; i++)
            {
                TongValue += (BooksToShow[i].GiaBan * BooksToShow[i].SoLuong);
            }
            TongTien = TongValue.ToString();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string PropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
    }
}
