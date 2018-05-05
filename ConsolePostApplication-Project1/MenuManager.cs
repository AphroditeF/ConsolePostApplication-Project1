using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePostApplication_Project1
{
    class MenuManager
    {
        public static void Basic(User puser) {
            //----------------  Basic Menu For All  ------------------------
            Console.WriteLine("");
            int i = 1;
            Console.WriteLine("To send a post, type {0}", i); i++;
            Console.WriteLine("To see all posts, type {0}", i); i++;


            if (puser.Role == "SuperAdmin")
            {
                Console.WriteLine("To assign roles, type {0}", i); i++;
                Console.WriteLine("To handle users, type {0}", i); i++;
            }

            Console.WriteLine("To log out, type 0");
        }
        
        
        
    }
}
