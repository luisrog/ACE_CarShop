using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAceCarShop.User
{
    public class UsAuth
    {
        public int IdUser { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public UsRole Role { get; set; }
        public string Photo { get; set; }
        public List<UsRoleModule> ListRoleModule  { get; set; }
        public List<UsRoleModulePrivilege> ListRoleModulePrivilege { get; set; }
    }
}
