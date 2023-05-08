﻿using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolPlatform.Models
{
    public class User
    {
        public int UserId { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public UserType UserType { get; set; }

        public User(string userName, string password, UserType userType) {
            UserName = userName;
            Password = password;
            UserType = userType;
        }
    }
}
