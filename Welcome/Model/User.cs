using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welcome.Others;

namespace Welcome.Model
{

    public class User
    {
        public User(String name, String password, UserRolesEnum role)
        {
            Name = name;
            Password = password;
            Role = role;
        }
        public User() { }
        public string Name { get; set; }
        public string Password { get; set; }
        public UserRolesEnum Role { get; set; }
    }
}

