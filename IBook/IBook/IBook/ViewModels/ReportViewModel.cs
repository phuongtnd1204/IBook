using IBook.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace IBook.ViewModels
{
    class ReportViewModel : INotifyPropertyChanged
    {
        public ICommand ToReportCommand { get; private set; }
        List<int> month;
        List<int> year;
        int monthSelected;
        int yearSelected;
        object tongtien;
        object soluong;
        DateTime date;
        public ReportViewModel()
        {
            invoiceRepository = new InvoiceRepository();
            month = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            year = new List<int> { 2017, 2018, 2019 };
            ToReportCommand = new Command(GetSumMoney,CanExe);
        }
        public async void GetSumMoney()
        {
            date = new DateTime(YearSelected, MonthSelected, 1);
            TongTien = (await invoiceRepository.ReportMoney(date));
            SoLuong = await invoiceRepository.ReportQuantity(date);
            RaisePropertyChanged("Report");
        }
        public bool CanExe()
        {
            if (YearSelected==0 || MonthSelected==0)
                return false;
            else
                return true;
        }
        public List<int> Month
        {
            get { return month; }
            set
            {
                month = value;
                RaisePropertyChanged("Month");
            }
        }
        public List<int> MonthDisplay
        {
            get { return month; }
            set
            {
                month = value;
                RaisePropertyChanged("MonthDisplay");
            }
        }
        public int MonthSelected
        {
            get { return monthSelected; }
            set
            {
                monthSelected = value;
                RaisePropertyChanged("MonthSelected");
                ((Command)ToReportCommand).ChangeCanExecute();
            }
        }
        public List<int> Year
        {
            get { return year; }
            set
            {
                year = value;
                RaisePropertyChanged("Year");
            }
        }
        public List<int> YearDisplay
        {
            get { return year; }
            set
            {
                year = value;
                RaisePropertyChanged("YearDisplay");
            }
        }
        public int YearSelected
        {
            get { return yearSelected; }
            set
            {
                yearSelected = value;
                RaisePropertyChanged("YearSelected");
                ((Command)ToReportCommand).ChangeCanExecute();
            }
        }
        public object TongTien
        {
            get { return tongtien; }
            set
            {
                tongtien = value;
                RaisePropertyChanged("TongTien");
            }
        }
        public object SoLuong
        {
            get { return soluong; }
            set
            {
                if (value == null)
                {
                    soluong = 0;
                }
                else
                {
                    soluong = value;
                }
                RaisePropertyChanged("SoLuong");
            }
        }
        private InvoiceRepository invoiceRepository { get; set; }
        public ObservableCollection<object> Report { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string PropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
    }
}
