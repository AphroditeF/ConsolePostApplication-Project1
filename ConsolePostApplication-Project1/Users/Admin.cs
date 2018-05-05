using ConsolePostApplication_Project1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePostApplication_Project1
{
    public class Admin : User, IMessageSendable, IPostsEditable
    {
       // public new string Role = "Admin";

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


        //Later

        public void PullPostsBySender(string username) { }
        public void PullPostsByReceiver(string username) { }
        public void PullPostsByDate(DateTime date) { }

        
    }
}
