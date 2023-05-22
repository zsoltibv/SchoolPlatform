using Microsoft.EntityFrameworkCore;
using SchoolPlatform.DAL;
using SchoolPlatform.Models;
using SchoolPlatform.StoredProcedures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace SchoolPlatform.Data
{
    public class DataContextSingleton
    {
        private static DataContext _instance;

        public DataContextSingleton() { 
        }

        public static DataContext Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DataContext();
                }
                return _instance;
            }
        }

        public static void SeedData()
        {
            if (!Instance.Users.Any(u => u.UserType == UserType.Admin))
            {
                DbSeeder.SeedAdminUser(Instance);
                DbSeeder.SeedYearOfStudy(Instance);
                DbSeeder.SeedSpecialization(Instance);
                DbSeeder.SeedSubjects(Instance);
                DbSeeder.SeedStoredProcedures(Instance);
            }
        }
    }
}
