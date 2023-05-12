using Microsoft.EntityFrameworkCore;
using SchoolPlatform.Data;
using SchoolPlatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

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

        public static void SeedYearOfStudy(DataContext context)
        {
            for (int i = 1; i < 12; i++)
            {
                if (!context.YearOfStudy.Any(u => u.Year == i))
                {
                    YearOfStudy yearOfStudy = new YearOfStudy
                    {
                        Year = i,
                    };
                    context.YearOfStudy.Add(yearOfStudy);
                    context.SaveChanges();
                }
            }
        }

        public static void SeedSpecialization(DataContext context)
        {
            if (!context.Specialization.Any(u => u.SpecializationName == "Mate-Info"))
            {
                Specialization specialization = new Specialization
                {
                    SpecializationName = "Mate-Info"
                };

                context.Specialization.Add(specialization);
                context.SaveChanges();
            }
            if (!context.Specialization.Any(u => u.SpecializationName == "Uman"))
            {
                Specialization specialization = new Specialization
                {
                    SpecializationName = "Uman"
                };

                context.Specialization.Add(specialization);
                context.SaveChanges();
            }
        }
    }
}
