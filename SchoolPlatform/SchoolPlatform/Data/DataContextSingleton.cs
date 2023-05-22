using Microsoft.EntityFrameworkCore;
using SchoolPlatform.DAL;
using SchoolPlatform.StoredProcedures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolPlatform.Data
{
    public class DataContextSingleton
    {
        private static DataContext _instance;

        public DataContextSingleton() {
            SeedData();
            CreateStoredProcedures();
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
            //seed dummy data
            DbSeeder.SeedAdminUser(Instance);
            DbSeeder.SeedYearOfStudy(Instance);
            DbSeeder.SeedSpecialization(Instance);
            DbSeeder.SeedSubjects(Instance);
        }

        public static void CreateStoredProcedures() {
            //seed stores procedures
            var averageTableSP = new AverageTableSP(Instance);

            // Call the methods to create stored procedures
            averageTableSP.CreateAddAverageStoredProcedure();
            averageTableSP.CreateDeleteAverageStoredProcedure();
            averageTableSP.CreateUpdateAverageStoredProcedure();
            averageTableSP.CreateGetAveragesStoredProcedure();
            averageTableSP.CreateGetAverageByIdStoredProcedure();
        }
    }
}
