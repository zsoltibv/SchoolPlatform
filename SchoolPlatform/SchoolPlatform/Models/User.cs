using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolPlatform.Models
{
    public class User
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public UserRole Role { get; set; }

        public User(string userName, string password, UserRole role) {
            UserName = userName;
            Password = password;
            Role = role;
        }
    }
}
