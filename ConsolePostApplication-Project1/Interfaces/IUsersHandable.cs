using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePostApplication_Project1.Interfaces
{
    interface IUsersHandable
    {
        void CreateUser(string username, string password);
        void DeleteUser(string username, string current);
        void ChangeUsername(User old,string newU, string currentUsername);
        void ChangePassword(string username, string newPassword);
    }
}
