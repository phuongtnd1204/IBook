using IBook.Models;
using IBook.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IBook.Repository
{
    public class InvoiceRepository
    {
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
        {

        }
        public void SelectById()
        {

        }


    }
}
