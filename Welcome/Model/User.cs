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
        private int id;
        private DateTime expires;
        public User(String name, String password, UserRolesEnum role)
        {
            Name = name;
            Password = password;
            Role = role;
        }
        public User() { }
        public int Id
        {
            get => id;
            set => id = value;
        }
        public string Name { get; set; }
        public string Password { get; set; }
        public UserRolesEnum Role { get; set; }
        public DateTime Expires
        { 
            get => expires;
            set => expires = value;
        }

    }
}

