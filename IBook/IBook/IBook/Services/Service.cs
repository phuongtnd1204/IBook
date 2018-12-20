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
            urlHome = "http://localhost:49386";
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
                    if (user.IsAdmin == true)
                        return 1;
                    else
                        return 2;
                }
            }
            return 3;
 
        }
        public bool SignUp(User user)
        {
            URL = urlHome + "api/user/LogIn";
            var json = JsonConvert.SerializeObject(user);

            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var httpResponse = await Client.PostAsync(URL, data).Result;
            if (httpResponse.IsSuccessStatusCode)
            {
                return true;
            }
            else return false;
        }

        public async  Task<List<User>> ListAllUser()
        {
            URL = urlHome + "api/users";
            var httpResponse = await Client.GetAsync(URL);
                var responseList = httpResponse.Content.ReadAsStringAsync().Result;
                var userList = JsonConvert.DeserializeObject<List<User>>(responseList);
                return userList;
        }
        public List<Book> ListAllBook()
        {

        }
        public List<BookKind> ListAllBookKind()
        {

        }
        public List<Author> ListAllAuthor()
        {

        }
    }
}
