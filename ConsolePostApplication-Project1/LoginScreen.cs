using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePostApplication_Project1
{
    public class LoginScreen
    {
        public static User LoginUser()
        {
            //---- Login Screen -----
            User user;
            string username, password;
            bool result = false;
            do
            {
                Console.WriteLine("Please, insert your username!");
                username = Console.ReadLine();
                Console.WriteLine("Please, insert your password!");
                password = Console.ReadLine();
                user = new User
                {
                    Username = username,
                    Password = password
                };
                result = DBCommands.LoginUser(user);
            } while (result == false);

            //check Role
            user.Role = user.FindRole();
            Console.WriteLine("Your Role is {0}", user.Role);

            return user;
        }
    }
}
