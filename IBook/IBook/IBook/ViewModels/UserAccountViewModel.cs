using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using IBook.Models;
using IBook.Repository;
using Xamarin.Forms;

namespace IBook.ViewModels
{
    public class UserAccountViewModel: INotifyPropertyChanged
    {
        public UserAccountViewModel()
        {
            ToDetailCommand = new Command(ToDetail);
            LogOutCommand = new Command(LogOut);
            LoadData();
        }

        public void LoadData()
        {
            HoVaTen = App.mainUser.TenNguoiDung;
            SoDienThoai = App.mainUser.SoDienThoai;
            TenDangNhap = App.mainUser.TenDangNhap;
            BillQuantity = App.mainUser.SoHoaDon;
            MoneyQuantity = App.mainUser.Tien;
        }
        public object bill;
        public object money;
        private InvoiceRepository invoiceRepository { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string PropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        public object BillQuantity
        {
            get { return bill; }
            set
            {
                if (value == null)
                {
                    bill = 0;
                }
                bill = value;
                RaisePropertyChanged("BillQuantity");
            }
        }

        public object MoneyQuantity
        {
            get { return money; }
            set
            {
                if (value == null)
                {
                    money = 0;
                }
                money = value;
                RaisePropertyChanged("MoneyQuantity");
            }
        }

        public ICommand ToDetailCommand { get; private set; }
        public ICommand LogOutCommand { get; private set; }

        public string HoVaTen { get; set; }
        public string SoDienThoai { get; set; }
        public string TenDangNhap { get; set; }
        private void ToDetail()
        {
            Application.Current.MainPage.Navigation.PushAsync(new View.PageUserAccountDetail());
        }

        private void LogOut()
        {
            App.listChon = null;
            App.mainUser = null;
            Application.Current.MainPage.Navigation.PushAsync(new View.PageLogin());
        }

    }
}
