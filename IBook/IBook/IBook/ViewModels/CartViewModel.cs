using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
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
        private ObservableCollection<Book> _booksToShow;
        public ObservableCollection<Book> BooksToShow
        {
            get { return _booksToShow; }
            set
            {
                _booksToShow = value;
                RaisePropertyChanged(nameof(BooksToShow));
                RaisePropertyChanged(nameof(TongTien));
            }
        }
        private string _tongTien;
        public string TongTien
        {
            get
            {
                if (BooksToShow == null) return "0";
                int TongValue = 0;
                for (int i = 0; i < BooksToShow.Count; i++)
                {
                    TongValue += (BooksToShow[i].GiaBan * BooksToShow[i].SoLuong);
                }
                return TongTien = TongValue.ToString();
            }
            set
            {
                _tongTien = value;
                RaisePropertyChanged("TongTien");
            }
        }
        private string _diachi;
        public  string DiaChi {
            get { return _diachi; }
            set
            {
                _diachi = value;
                RaisePropertyChanged("DiaChi");
                ((Command)ConfirmCommand).ChangeCanExecute();
            }
        }
        public  ICommand ConfirmCommand { get; set; }
        public ICommand DeleteBookCommand { get; set; }
        public  Book ChosenBook { get; set; }
        public CartViewModel()
        {
            this.DeleteBookCommand = new Command<Book>(DeleteBook);
            if (App.listChon != null)
            {
                invoice = new Invoice();
                InvoiceDetail = new InvoiceDetail();
                bookRepository = new BookRepository();
                ConfirmCommand = new Command(Confirm,CanExe);
                invoiceRepository = new InvoiceRepository();
                InvoiceDetailRepository = new InvoiceDetailRepository();
                ChosenBook = new Book();
                LoadData();
            }
        }

        private bool CanExe()
        {
            if (string.IsNullOrEmpty(_diachi)) return false;
            return true;
        }
        private void DeleteBook(Book item)
        {
            App.listChon.Remove(item.MaSach.ToString());
            LoadData();
        }
        private async void Confirm()
        {
            invoice.MaNguoiDung = App.mainUser.MaNguoiDung;
            invoice.TongTien = int.Parse(TongTien);
            invoice.DiaChi = DiaChi;
            invoice.NgayHoaDon = DateTime.Now;
            await invoiceRepository.Add(invoice);
            for (int i = 0; i < BooksToShow.Count; i++)
            {
                InvoiceDetail = new InvoiceDetail() { MaHoaDon = 1, DonGia = BooksToShow[i].GiaBan, MaSach = BooksToShow[i].MaSach, SoLuong = BooksToShow[i].SoLuong, ThanhTien = (BooksToShow[i].GiaBan * BooksToShow[i].SoLuong) };
                await InvoiceDetailRepository.Add(InvoiceDetail);
            }
            App.Current.MainPage.DisplayAlert("Thông báo", "Đặt mua thành công", "OK");
            App.mainUser.SoHoaDon = (int.Parse(App.mainUser.SoHoaDon) + 1).ToString();
            App.mainUser.Tien = (int.Parse(App.mainUser.Tien) + invoice.TongTien).ToString();
            App.listChon.Clear();
            TongTien = "0";
            DiaChi = "";
            RaisePropertyChanged("DiaChi");
            LoadData();
        }

        private async void LoadData()
        {
            if (App.listChon != null)
            {
                BooksToShow = new ObservableCollection<Book>(await bookRepository.ListSomeBook());
                foreach (Book item in BooksToShow)
                {
                    object str = item.Hinh;
                    item.Hinh = Xamarin.Forms.ImageSource.FromStream(
                    () => new MemoryStream(Convert.FromBase64String(str.ToString())));
                    item.SoLuong = 1;
                }
                RaisePropertyChanged("BooksToShow");
                RaisePropertyChanged("TongTien");
            }
            else
            {
                BooksToShow = null;
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string PropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
    }
}
