using IBook.Models;
using IBook.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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
        public async Task<bool> SignUp(User user)
        {
            return await service.SignUp(user);
        }
<<<<<<< HEAD
        public async Task<List<User>> ListAll()
=======
        public async Task<List<User>> ListAllAsync()
>>>>>>> 45134c2f879e68129cd9fe22cac20f60e9dfae89
        {
            return await service.ListAllUser();
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
