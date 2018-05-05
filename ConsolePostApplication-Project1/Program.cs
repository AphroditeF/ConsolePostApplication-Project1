using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ConsolePostApplication_Project1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Code for first run   It can be uncommented by using Singleton Pattern, but I don't have time 

            /*
            SimpleUser test1 = new SimpleUser("test1", "test1");
            DBCommands.InsertSimpleUser(test1);

            SimpleUser test2 = new SimpleUser("test2", "test2");
            DBCommands.InsertSimpleUser(test2);

            SimpleUser test3 = new SimpleUser("test3", "test3");
            DBCommands.InsertSimpleUser(test3);

            Admin test4=new Admin("test4","test4");
            DBCommands.InsertAdmin(test4);

            Admin test5 = new Admin("test5", "test5");
            DBCommands.InsertAdmin(test5);

            SuperAdmin test6 = new SuperAdmin("admin", "aDmI3$");
            DBCommands.InsertSuperAdmin(test6);
            
            Post post = new Post()
            {
                SenderUsername = "test1",
                ReceiverUsername = "test2",
                Message = "test",
                Date = DateTime.Now

            };
            DBCommands.NewPost(post);
            */

            User user = new User();
            user = LoginScreen.LoginUser();

            

            //--------------------------------------------I' m trying to create new object of kids' classes or cast
            //var currentUser = user.CreateCurrentUser();
            //int a=MenuManager.Basic(currentUser as User); 

            App.Run(user);
            
            Console.ReadKey();
        }

      
    }
}
