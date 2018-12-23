using IBook.Models;
using IBook.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
<<<<<<< HEAD
=======
using IBook.Models;
using IBook.Services;
>>>>>>> 984b6d526975cac5c6e8334dd2f3039eb56a09b3

namespace IBook.Repository
{
    public class InvoiceRepository
    {
<<<<<<< HEAD
        private Service service { get; set; }
        public InvoiceRepository()
        {
            service = new Service();
        }
        public async Task<object> ReportMoney(DateTime date)
        {
            return await service.ReportMoney(date);
        }
        public async Task<object> ReportQuantity(DateTime date)
        {
            return await service.ReportQuantity(date);
        }
        public void Add()
=======

        private  Service service { get; set; }
        public async Task<bool> Add(Invoice invoice)
>>>>>>> 984b6d526975cac5c6e8334dd2f3039eb56a09b3
        {
            return await service.ConfirmInvoice(invoice);
        }

        public InvoiceRepository()
        {
            service = new Service();
        }
        public void SelectById()
        {
           
        }


    }
}
