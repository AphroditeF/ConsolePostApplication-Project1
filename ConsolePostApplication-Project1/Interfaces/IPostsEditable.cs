﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePostApplication_Project1.Interfaces
{
    interface IPostsEditable:IPostsViewable
    {
         bool EditPost(int postId, string postMessage);
        bool FindPost(int postId);
    }
}
