using IBook.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace IBook.Services
{
    class Service
    {
        HttpClient Client { get; set; } 

        string URL { get; set; }
        string urlHome { get; set; }
        object obj { get; set; }
        public Service()
        {
            URL = "";
            urlHome = "https://webapplication120181217021027.azurewebsites.net/";
            Client  = new HttpClient();
        }


        public int SignIn(string tendn, string matkhau)
        {
            URL = urlHome + "api/user/LogIn";
            obj = new { TenDangNhap = tendn, MatKhau = matkhau };
            var json = JsonConvert.SerializeObject(obj);

            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var httpResponse = Client.PostAsync(URL, data).Result;
            if(httpResponse.IsSuccessStatusCode)
            {
                var responseString = httpResponse.Content.ReadAsStringAsync().Result;
                var user = JObject.Parse(responseString)["Result"].ToObject<User>();
                if (user == null)
                {
                    return 0;
                }
                else
                {
                    App.mainUser = new User();
                    App.mainUser = user;
                    if (user.IsAdmin == 1)
                        return 1;
                    else
                        return 2;
                }
            }
            return 3;
 
        }
        public async Task<bool> SignUp(User user)
        {
            URL = urlHome + "api/user/add";
            user.IsAdmin = 0;
            var json = JsonConvert.SerializeObject(user);

            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var httpResponse = await Client.PostAsync(URL, data);
            if (httpResponse.IsSuccessStatusCode)
            {
                return true;
            }
            else return false;
        }

        public async Task<bool> ConfirmInvoice(Invoice invoice)
        {
            URL = urlHome + "api/invoice/add";
            var json = JsonConvert.SerializeObject(invoice);

            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var httpResponse = await Client.PostAsync(URL, data);
            if (httpResponse.IsSuccessStatusCode)
            {
                return true;
            }
            else return false;
        }

        public async Task<bool> ConfirmInvoiceDetail(InvoiceDetail invoiceDetail)
        {
            URL = urlHome + "api/invoicedetail/add";
            var json = JsonConvert.SerializeObject(invoiceDetail);

            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var httpResponse = await Client.PostAsync(URL, data);
            if (httpResponse.IsSuccessStatusCode)
            {
                return true;
            }
            else return false;
        }

        public async Task<List<User>> ListAllUser()
        {
            URL = urlHome + "api/users";
            var httpResponse = await Client.GetAsync(URL);
            var responseList = await httpResponse.Content.ReadAsStringAsync();
            //var userList = JsonConvert.DeserializeObject<List<User>>(responseList);
            var userList = JObject.Parse(responseList)["Result"].ToObject<List<User>>();
            return userList;
        }

        public async Task<List<Book>> ListAllBook()
        {
            URL = urlHome + "api/books";
            var httpResponse = await Client.GetAsync(URL);
            var responseList = await httpResponse.Content.ReadAsStringAsync();
            //var userList = JsonConvert.DeserializeObject<List<User>>(responseList);
            var userList = JObject.Parse(responseList)["Result"].ToObject<List<Book>>();
            return userList;
        }

        public async Task<Book> SelectBook( int id)
        {
            URL = urlHome + "api/book?masach=" + id;
            var httpResponse = await Client.GetAsync(URL);
            var responseList = await httpResponse.Content.ReadAsStringAsync();
            //var userList = JsonConvert.DeserializeObject<List<User>>(responseList);
            var book = JObject.Parse(responseList)["Result"].ToObject<Book>();
            return book;
        }

        public async Task<Author> SelectAuthor(int id)
        {
            URL = urlHome + "api/author?matacgia=" + id;
            var httpResponse = Client.GetAsync(URL).Result;
            var responseList = httpResponse.Content.ReadAsStringAsync().Result;
            var author = JObject.Parse(responseList)["Result"].ToObject<Author>();
            return author;
        }

        public BookKind SelectBookKind(int id)
        {
            URL = urlHome + "api/bookkind?matheloai=" + id;
            var httpResponse = Client.GetAsync(URL).Result;
            var responseList =  httpResponse.Content.ReadAsStringAsync().Result;
            var bookKind = JObject.Parse(responseList)["Result"].ToObject<BookKind>();
            return bookKind;
        }

        public async Task<List<BookKind>> ListAllBookKind()
        {
            URL = urlHome + "api/bookkinds";
            var httpResponse = await Client.GetAsync(URL);
            var responseList = await httpResponse.Content.ReadAsStringAsync();
            //var userList = JsonConvert.DeserializeObject<List<User>>(responseList);
            var bookKindList = JObject.Parse(responseList)["Result"].ToObject<List<BookKind>>();
            return bookKindList;
        }
        public async Task<List<Author>> ListAllAuthor()
        {
            URL = urlHome + "api/authors";
            var httpResponse = await Client.GetAsync(URL);
            var responseList = await httpResponse.Content.ReadAsStringAsync();
            //var userList = JsonConvert.DeserializeObject<List<User>>(responseList);
            var authorList = JObject.Parse(responseList)["Result"].ToObject<List<Author>>();
            return authorList;
        }

        public async Task<bool> UpdateUser(User user)
        {
            URL = urlHome + "api/user/update";
            var json = JsonConvert.SerializeObject(user);

            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var httpResponse = await Client.PutAsync(URL, data);
            var responseList = await httpResponse.Content.ReadAsStringAsync();
            if (httpResponse.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> UpdateBook(Book book)
        {
            URL = urlHome + "api/book/update";
            var json = JsonConvert.SerializeObject(book);

            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var httpResponse = await Client.PutAsync(URL, data);
            var responseList = await httpResponse.Content.ReadAsStringAsync();
            if (httpResponse.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<List<Book>> ListChosenBook()
        {
            List<Book> bookList = new List<Book>();
            for (int i = 0; i < App.listChon.Count; i++)
            {
                URL = urlHome + "api/book?masach=" + App.listChon[i];
                var httpResponse = await Client.GetAsync(URL);
                var responseList = await httpResponse.Content.ReadAsStringAsync();
                var book = JObject.Parse(responseList)["Result"].ToObject<Book>();
                book.SoLuong = 1;
                bookList.Add(book);
            }
            return bookList;
        }

        public async Task<object> GetInfo(int id)
        {
            URL = urlHome + "api/book/author-bookkind-name?masach=" + id;
            var httpResponse = await Client.GetAsync(URL);
            var responseList = await httpResponse.Content.ReadAsStringAsync();
            //var userList = JsonConvert.DeserializeObject<List<User>>(responseList);
            var Info = JObject.Parse(responseList)["Result"].ToObject<object>();
            return Info;
        }
    }
}
