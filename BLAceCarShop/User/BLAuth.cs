using DAAceCarShop.User;
using EAceCarShop.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLAceCarShop.User
{
    public class BLAuth
    {
        public UsAuth getAuthForIdUser(string email, string passwd) 
        {
            return new DAAuth().getAuthForIdUser(email, passwd);
        }
    }
}
