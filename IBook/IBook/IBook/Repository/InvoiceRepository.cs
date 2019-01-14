using IBook.Models;
using IBook.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using IBook.Models;
using IBook.Services;

namespace IBook.Repository
{
    public class InvoiceRepository
    {
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
        public async Task<object> ReportMoneyQuantity(int id)
        {
            return await service.ReportMoneyQuantity(id);
        }

        public async Task<object> ReportBillQuantity(int id)
        {
            return await service.ReportBillQuantity(id);
        }

        public void Add()
        {

        }

        private  Service service { get; set; }
        public async Task<bool> Add(Invoice invoice)
        {
            return await service.ConfirmInvoice(invoice);
        }
        public void SelectById()
        {
           
        }


    }
}
