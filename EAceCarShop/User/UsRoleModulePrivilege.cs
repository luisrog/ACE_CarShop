using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAceCarShop.User
{
    public class UsRoleModulePrivilege
    {
        public int Id { get; set; }
        public UsRole Role { get; set; }
        public UsModule Module { get; set; }
        public UsPrivilege Privilege { get; set; }
        public string UserCreate { get; set; }
        public DateTime DateCreate { get; set; }
    }
}
