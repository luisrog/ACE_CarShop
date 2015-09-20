using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAceCarShop.User
{
    public class UsUser
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Passwd { get; set; }
        public UsState State { get; set; }
        public UsRole Role { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Dni { get; set; }
        public string Ruc { get; set; }
        public DateTime BirthDate { get; set; }
        public string Subscribed { get; set; }
        public string Photo { get; set; }
        public string UserCreate { get; set; }
        public DateTime DateCreate { get; set; }
        public string UserUpdate { get; set; }
        public DateTime ? DateUpdate { get; set; }
    }
}
