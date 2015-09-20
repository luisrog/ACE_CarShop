using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAceCarShop.User
{
    public class UsRole
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public UsState State { get; set; }
        public string UserCreate { get; set; }
        public DateTime DateCreate { get; set; }
        public string UserUpdate { get; set; }
        public DateTime ? DateUpdate { get; set; }
    }
}
