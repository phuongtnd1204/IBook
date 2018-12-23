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
        public async Task<int> GetSumMoney(DateTime date)
        {
            return await service.GetSumMoney(date);
        }
        public void Add()
        {

        }
        public void SelectById()
        {

        }


    }
}
