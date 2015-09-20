using DAAceCarShop.User;
using EAceCarShop.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLAceCarShop.User
{
    public class BLUser
    {
        public UsUser getUserForID(int id)
        {
            return new DAUser().getUserForID(id);
        }

        public List<UsUser> getUserAll()
        {
            return new DAUser().getUserAll();
        }

        public bool insertUser(UsUser u)
        {
            return new DAUser().insertUser(u);
        }

        public bool updateUser(UsUser u)
        {
            return new DAUser().updateUser(u);
        }

        public bool deleteUser(UsUser u)
        {
            return new DAUser().deleteUser(u);
        }
    }
}
