using DAAceCarShop.User;
using EAceCarShop.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLAceCarShop.User
{
    public class BLRole
    {
        public List<UsRole> getRoleForState(int idState) 
        {
            return new DARole().getRoleForState(idState);
        }
    }
}
