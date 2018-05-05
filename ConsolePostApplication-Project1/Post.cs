using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePostApplication_Project1
{
    public class Post
    {
        //Domain Model of table Posts
        //Scalar Properties
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }
        public bool ConditionEdited { get; set; }

        public string SenderUsername { get; set; }
        public string ReceiverUsername { get; set; }

        public User Sender { get; set; }
        public User Receiver { get; set; }
        
    }
}
