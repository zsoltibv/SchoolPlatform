using Microsoft.EntityFrameworkCore;
using SchoolPlatform.Data;
using SchoolPlatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolPlatform.DAL
{
    public class DbSeeder
    {
        public static void SeedAdminUser(DataContext context)
        {
            if (!context.Users.Any(u => u.UserName == "admin"))
            {
                var adminUser = new User("admin", "pass", UserType.Admin);
                context.Users.Add(adminUser);
                context.SaveChanges();
            }
        }
    }
}
