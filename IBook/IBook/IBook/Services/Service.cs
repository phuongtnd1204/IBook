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
                    App.Current.Properties["ID"] = user.MaNguoiDung;
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
    }
}
