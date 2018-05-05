using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ConsolePostApplication_Project1
{
    public class DBCommands
    {
        //----------------------  Insert new Users about demo objects ------------------------------------------
        public static void InsertSimpleUser(SimpleUser user)
        {
            using (var db = new PostingContext())
            {
                db.Users.Add(user);
                db.SaveChanges();
            }
        }

        //Insert new Admin
        public static void InsertAdmin(Admin user)
        {
            using (var db = new PostingContext())
            {
                db.Users.Add(user);
                db.SaveChanges();
            }

        }

        //Insert new Super Admin
        public static void InsertSuperAdmin(SuperAdmin user)
        {
            using (var db = new PostingContext())
            {
                db.Users.Add(user);
                db.SaveChanges();
            }

        }
        //--------------------   Insert new Users for App.cs ---------------------------------------------

        public static void InsertNewSimpleUser(string username, string password)
        {
            var user = new SimpleUser { Username = username, Password = password, Role = "SimpleUser" };

            using (var db = new PostingContext())
            {
                db.Users.Add(user);
                db.SaveChanges();
            }
        }






        public void InsertNewSuperAdmin(string username, string password)
        {
            var user = new SuperAdmin { Username = username, Password = password };


            using (var db = new PostingContext())
            {
                db.Users.Add(user);
                db.SaveChanges();

            }

        }

        public void InsertNewAdmin(string username, string password)
        {
            var user = new SuperAdmin { Username = username, Password = password };


            using (var db = new PostingContext())
            {
                db.Users.Add(user);
                db.SaveChanges();

            }

        }
        //-----------------------   Users  ---------------------------------------------------------
        //LoginUser
        public static bool LoginUser(User user)
        {
            using (var db = new PostingContext())
            {
                var result = db.Users.Where(u => u.Username == user.Username && u.Password == user.Password).FirstOrDefault();
                if (result != null)
                {
                    Console.WriteLine("Welcome {0}", result.Username);
                    return true;
                }
                else {
                    Console.WriteLine("Please, try again! ");
                    return false;
                }
            }
        }
        //FindUser
        public static bool FindUser(string user)
        {
            using (var db = new PostingContext())
            {
                var result = db.Users.Where(u => u.Username == user).FirstOrDefault();
                if (result != null)
                {
                    return true;
                }
                else
                {

                    return false;
                }
            }
        }

        public static void PullUsers()
        {
            var listUsers = new List<User>();
            using (var db = new PostingContext())
            {
                listUsers = db.Users.ToList();

            }

            Console.WriteLine("All users:");
            foreach (var u in listUsers)
            {
                Console.WriteLine("{0}\t", u.Username);
            }

        }
        public static void PullUsersRoles()
        {
            var listUsers = new List<User>();
            using (var db = new PostingContext())
            {
                listUsers = db.Users.ToList();

            }

            Console.WriteLine("All users:");
            foreach (var u in listUsers)
            {
                Console.WriteLine("{0}\t {1}", u.Username, u.Role);
            }

        }
        public static User PullUser(string name)
        {
            using (var db = new PostingContext())
            {
                var result = db.Users.Where(u => u.Username == name).FirstOrDefault();
                return result;
            }
        }

        public static void ChangeUsername(User oldU, string newU,string currentU)
        {
            using (var db = new PostingContext())
            {

                if (oldU.Username == currentU) {
                    Console.WriteLine("Current User cannot delete himself"); }
                else
                {
                    User oldUser = new User();
                    oldUser=oldUser.PullUser(oldU.Username);
                    
                    User newUser = new User() { Username = newU, Password = oldUser.Password, Role = oldUser.Role};
                    db.Users.Remove(oldUser);
                    db.Users.Add(newUser);
                    

                    db.SaveChanges();


                }
                

            }
        }

        public static void ChangePassword(string name, string pass)
        {
            using (var db = new PostingContext())
            {

                if (DBCommands.FindUser(name))
                {


                    var user = db.Users.Where(u => u.Username == name).FirstOrDefault();
                    //DBCommands.
                    user.Password = pass;

                    db.SaveChanges();


                }
                else
                {
                    Console.WriteLine("Changing password was cancelled.Please try again and use a unique username.");
                }

            }
        }

        public static void DeleteUser(string deleteUser, string user)
        {
            using (var db = new PostingContext())
            {

                if (DBCommands.FindUser(deleteUser))
                {
                    if (deleteUser == user)
                    {
                        Console.WriteLine("The current user cannot be deleted!!");
                    }
                    else
                    {

                        var duser = db.Users.FirstOrDefault(u => u.Username == deleteUser);
                        db.Users.Remove(duser);
                        db.SaveChanges();
                        

                    }
                }
                else
                {
                    Console.WriteLine("Changing username was cancelled.Please try again and use a unique username.");
                }

            }
        }




        //--------------------------  Users' Roles     -----------------------------------------------
        public static void ChangeRoles(string username, string Role)
        {
            using (var db = new PostingContext())
            {
                var user = db.Users.FirstOrDefault(u => u.Username == username);
                user.Role = Role;
                db.SaveChanges();
            }
        }
        //--------------------------------  POSTS  ------------------------------------------------------

        //Insert new Post
        public static void NewPost(Post post)
        {
            using (var db = new PostingContext())
            {
                db.Posts.Add(post);
                db.SaveChanges();
            }

        }
        public static Post PullPost(int id)
        {
            using (var db = new PostingContext())
            {
                var result = db.Posts.Where(p => p.Id == id).FirstOrDefault();
                return result;
            }
        }

        public static void PullPosts()
        {
            var listPosts = new List<Post>();
            using (var db = new PostingContext())
            {
                listPosts = db.Posts.ToList();

            }
            Console.Write("\n");
            foreach (var p in listPosts)
            {
                Console.Write($"Id: {p.Id} On {p.Date},{p.SenderUsername} send a Post with message {p.Message} to {p.ReceiverUsername}. This post was ");
                if (!p.ConditionEdited)
                {
                    Console.Write("not ");
                }
                Console.Write("edited. \n");

            }
        }
        
        public static bool FindPost(int id)
        {
            using (var db = new PostingContext())
            {
                var result = db.Posts.Where(p => p.Id == id).FirstOrDefault();
                if (result != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public static bool EditPost(int id, string message){
            bool result = false;
            result=FindPost(id);
            if (result)
            {
                using(var db =new PostingContext())
                {
                    var post = db.Posts.Where(p => p.Id == id).FirstOrDefault();
                    post.Message = message;
                    post.ConditionEdited = true;
                    db.SaveChanges();
                    
                }
                return true;
            }
            return false;
        }

        public static void DeletePost(int id)
        {
            using (var db =new PostingContext()){
                var post = db.Posts.FirstOrDefault(p => p.Id == id);
                db.Posts.Remove(post);
                db.SaveChanges();
            }
        }
        


    }

}

