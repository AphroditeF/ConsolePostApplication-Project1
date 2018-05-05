using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePostApplication_Project1.Interfaces
{
    interface IPostsViewable
    {

        void PullPosts();
        
        void PullPostsBySender(string username);
        void PullPostsByReceiver(string username);
        void PullPostsByDate(DateTime date);
    }
}
