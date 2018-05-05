using ConsolePostApplication_Project1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePostApplication_Project1
{
    public class SuperAdmin : User, IMessageSendable, IPostsEditableDeletable,IRolesAssignable,IUsersHandable
    {
        //public new string Role = "Admin";

        public void SendPost(Post post)
        {

            DBCommands.NewPost(post);
            //+++ Check post was sent succesfully
        }
        public void PullPosts()
        {
            DBCommands.PullPosts();
        }

        public bool EditPost(int postId, string postMessage)
        {
            return (DBCommands.EditPost(postId, postMessage));
        }
        public bool FindPost(int id)
        {
            return (DBCommands.FindPost(id));
        }
        public void DeletePost(int id)
        {
            DBCommands.DeletePost(id);
        }
        public void ChangeRoles(string username,string role)
        {
            DBCommands.ChangeRoles(username, role);
        }
        public void CreateUser(string username,string password)
        {
            SimpleUser user = new SimpleUser() { Username = username, Password = password };
            DBCommands.InsertNewSimpleUser(user.Username,user.Password);
        }
        public void ChangeUsername(User old,string newU,string current){
            DBCommands.ChangeUsername(old, newU,current);
        }
        public void ChangePassword(string name,string password)
        {
            DBCommands.ChangePassword(name, password);
        }
        public void DeleteUser(string username,string currentUser) {
            DBCommands.DeleteUser(username,currentUser);
        }


        //Later

        public void PullPostsBySender(string username) { }
        public void PullPostsByReceiver(string username) { }
        public void PullPostsByDate(DateTime date) { }


    }
}










