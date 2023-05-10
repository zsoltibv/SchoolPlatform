using Microsoft.EntityFrameworkCore;
using SchoolPlatform.Data;
using SchoolPlatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace SchoolPlatform.DAL
{
    public class UserDataAccess
    {
        private readonly DataContext _dbContext;
        public UserDataAccess()
        {
            _dbContext = DataContextSingleton.Instance;
            DbSeeder.SeedAdminUser(_dbContext);
        }

        public User GetUserById(int id)
        {
            return _dbContext.Users.FirstOrDefault(u => u.UserId == id);
        }

        public List<User> GetAllUsers()
        {
            return _dbContext.Users.ToList();
        }

        public void AddUser(User user)
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
        }

        public void DeleteUser(User user)
        {
            _dbContext.Users.Remove(user);
            _dbContext.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            _dbContext.Entry(user).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public User GetUserByUsernameAndPassword(string username, string password)
        {
            return GetAllUsers().FirstOrDefault(u => u.UserName == username && u.Password == password);
        }
    }
}
