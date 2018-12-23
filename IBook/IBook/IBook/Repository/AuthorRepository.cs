using IBook.Models;
using IBook.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IBook.Repository
{
    public class AuthorRepository
    {
        private Service service { get; set; }
        public AuthorRepository()
        {
            service = new Service();
        }

        public void Add()
        {

        }
        public async Task<List<Author>> ListAll()
        {
            return await service.ListAllAuthor();
        }
        public void Update()
        {

        }
        public async Task<Author>  SelectById(int id)
        {
            return  service.SelectAuthor(id).Result;
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
