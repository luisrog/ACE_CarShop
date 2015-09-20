using DAAceCarShop.User;
using EAceCarShop.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLAceCarShop.User
{
    public class BLState
    {
        public List<UsState> getStateAll() 
        {
            return new DAState().getStateAll();
        }
    }
}
