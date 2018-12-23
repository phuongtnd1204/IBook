using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using IBook.Models;
using IBook.Services;

namespace IBook.Repository
{
    public class InvoiceDetailRepository
    {
        private Service service { get; set; }
        public async Task<bool> Add(InvoiceDetail invoiceDetail)
        {
            return await service.ConfirmInvoiceDetail(invoiceDetail);
        }
        public void SelectById()
        {

        }
        public InvoiceDetailRepository()
        {
            service = new Service();
        }
    }
}
