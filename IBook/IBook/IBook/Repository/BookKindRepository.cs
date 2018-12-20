using IBook.Models;
using IBook.Services;
using System;
using System.Collections.Generic;
using System.Text;

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
        public List<BookKind> ListAll()
        {
            return service.ListAllBookKind();
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
