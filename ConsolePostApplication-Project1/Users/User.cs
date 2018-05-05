using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePostApplication_Project1
{

    public class User
    {
        //--------------  Domain Model of table Users  ----------------------------------------------------------

        //Scalar Properties
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        //Navigation Properties
        public virtual List<Post> SentPosts { get; set; }
        public virtual List<Post> ReceivedPosts { get; set; }

        //--------------------   All Methods  -------------------------------------------------------------------
        //Returns Role
        public string FindRole()
        {
            using (var db = new PostingContext())
            {
                var result = db.Users.Where(u => u.Username == this.Username).FirstOrDefault();

                return result.Role;
            }
        }
        public User PullUser(string name)
        {
            using (var db = new PostingContext())
            {
                var result = db.Users.Where(u => u.Username == name).FirstOrDefault();

                return result;
            }
        }

        //a way of casting which doesn't work
        /*
        public object CreateCurrentUser()
        {
            if (this.Role == "SimpleUser")
            {
                SimpleUser user = new SimpleUser { Username = this.Username, Password = this.Password };
                return user;
            }
            else if (this.Role == "Admin")
            {
                Admin user = new Admin { Username = this.Username, Password = this.Password };
                return user;
            }
            else if (this.Role == "SuperAdmin")
            {
                SuperAdmin user = new SuperAdmin { Username = this.Username, Password = this.Password };
                return user;
            }
            else { return "error"; }

        }
        */



    }
}
