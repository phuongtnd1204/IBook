using IBook.Models;
using IBook.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IBook.Repository
{
    public class BookRepository
    {
        private Service service { get; set; }
        public BookRepository()
        {
            service = new Service();
        }

        public void Add()
        {

        }
        public async Task<List<Book>> ListAll()
        {
            return await service.ListAllBook();
        }
        public async Task<List<Book>> ListSomeBook()
        {
            return await service.ListChosenBook();
        }
        public async Task<bool> Update(Book book)
        {
            return await service.UpdateBook(book);
        }
        public async Task<Book> SelectById(int id)
        {
            return await service.SelectBook(id);
        }
        public void Delete(string ID)
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
