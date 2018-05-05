using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePostApplication_Project1.Interfaces
{
    interface IRolesAssignable
    {
        void ChangeRoles(string username, string newRole);
    }
}
