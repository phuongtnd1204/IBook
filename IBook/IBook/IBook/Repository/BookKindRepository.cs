using IBook.Models;
using IBook.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IBook.Repository
{
    public class BookKindRepository
    {
        private Service service { get; set; }
        public BookKindRepository()
        {
            service = new Service();
        }
        public void Add()
        {

        }
        public async Task<List<BookKind>> ListAll()
        {
            return await service.ListAllBookKind();
        }
        public void Update()
        {

        }
        public void SelectById()
        {

        }
        public void Delete()
        {

        }
        public void DeleteAll()
        {

        }
        public void SearchName()
        {

        }
    }
}
