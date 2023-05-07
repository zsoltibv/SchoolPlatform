using Microsoft.EntityFrameworkCore;
using SchoolPlatform.Data;
using SchoolPlatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace SchoolPlatform.ViewModels
{
    public class UserViewModel
    {
        private readonly DataContext _dbContext;

        public UserViewModel() {
            _dbContext = DataContextSingleton.Instance;
            AddUser(new User("Gabi", "pass", UserRole.Elev));
        }

        public void AddUser(User user)
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
        }
    }
}
