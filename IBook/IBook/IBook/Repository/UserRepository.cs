using IBook.Models;
using IBook.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace IBook.Repository
{
    public class UserRepository
    {
        Service service;

        public UserRepository()
        {
            service = new Service();
        }

        public int SignIn(string tenDangNhap, string matKhau)
        {
            return service.SignIn(tenDangNhap, matKhau);
        }
        public bool SignUp(User user)
        {
            return service.SignUp(user);
        }
        public List<User> ListAll()
        {
            return service.ListAllUser();
        }
        public void Update()
        {

        }
        public void Delete()
        {

        }
        public void DeleteAll()
        {

        }
        public void SelectById()
        {

        }
        public void SelectByName()
        {

        }
        public void SearchName()
        {

        }



    }
}
