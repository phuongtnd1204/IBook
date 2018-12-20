using IBook.Models;
using IBook.Repository;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using IBook.Services;

namespace IBook.ViewModels
{
    public class AccountManagementViewModel
    {
        public AccountManagementViewModel()
        {
            userRepository = new UserRepository();
            GetUserList();
<<<<<<< HEAD
        }
        public async void GetUserList()
        {
            UserList = new ObservableCollection<User>(await userRepository.ListAll());
        }
=======
;        }
>>>>>>> 45134c2f879e68129cd9fe22cac20f60e9dfae89
        private UserRepository userRepository { get; set; }

        private async void GetUserList()
        {
            UserList =  new ObservableCollection<User>(await userRepository.ListAllAsync()) ;
        }
        public ObservableCollection<User> UserList { get; set; }
    }
}
