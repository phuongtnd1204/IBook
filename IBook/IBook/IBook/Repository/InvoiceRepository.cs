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

        private  Service service { get; set; }
        public async Task<bool> Add(Invoice invoice)
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
