using IBook.Models;
using IBook.Services;
using System;
using System.Collections.Generic;
using System.Text;

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
        public List<Author> ListAll()
        {
            return service.ListAllAuthor();
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
