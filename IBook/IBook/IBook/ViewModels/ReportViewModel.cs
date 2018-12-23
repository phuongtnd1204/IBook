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
        int tongtien;
        int month;
        int year;
        public ReportViewModel()
        {
            invoiceRepository = new InvoiceRepository();
            DateTime date = new DateTime(Year, Month, 1);
            //ToReportCommand = new Command(GetSumMoney(date));
        }
        public async void GetSumMoney(DateTime date)
        {
            TongTien = await invoiceRepository.GetSumMoney(date);
            RaisePropertyChanged("Report");
        }
        public int TongTien
        {
            get { return tongtien; }
            set
            {
                tongtien = value;
                RaisePropertyChanged("TongTien");
            }
        }
        public int Month
        {
            get { return month; }
            set
            {
                month = value;
                RaisePropertyChanged("Month");
            }
        }
        public int Year
        {
            get { return year; }
            set
            {
                year = value;
                RaisePropertyChanged("Year");
            }
        }
        private InvoiceRepository invoiceRepository { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string PropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
    }
}
