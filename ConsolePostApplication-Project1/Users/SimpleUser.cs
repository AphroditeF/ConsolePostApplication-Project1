﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ConsolePostApplication_Project1.Interfaces;

namespace ConsolePostApplication_Project1
{
    public class SimpleUser : User,IMessageSendable,IPostsViewable {
        //public new string Role = "SimpleUser";
  
        public void SendPost(Post post)
        {

            DBCommands.NewPost(post);
          //+++ Check post was sent succesfully
        }
        public void PullPosts()
        {
            DBCommands.PullPosts();
        }



        //Later

        public void PullPostsBySender(string username) { }
        public void PullPostsByReceiver(string username) { }
        public void PullPostsByDate(DateTime date) { }

    }
}
