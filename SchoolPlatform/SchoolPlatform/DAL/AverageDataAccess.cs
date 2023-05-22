using Microsoft.Data.SqlClient;
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
    //using stored procedures
    public class AverageDataAccess
    {
        private readonly DataContext _dbContext;
        public AverageDataAccess()
        {
            _dbContext = DataContextSingleton.Instance;
        }

        public List<Average> GetAverage(int studentId, int subjectId)
        {
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@StudentId", studentId),
                new SqlParameter("@SubjectId", subjectId)
            };

            string query = "EXEC GetAverages @StudentId, @SubjectId";

            return _dbContext.Averages.FromSqlRaw(query, parameters).ToList();
        }

        public Average GetAverageById(int id)
        {
            var parameter = new SqlParameter("@Id", id);

            string query = "EXEC GetAverageById @Id";

            return _dbContext.Averages.FromSqlRaw(query, parameter).FirstOrDefault();
        }

        public void AddAverage(Average average)
        {
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@AverageGrade", average.AverageGrade),
                new SqlParameter("@IsFinal", average.IsFinal),
                new SqlParameter("@StudentId", average.StudentId),
                new SqlParameter("@SubjectId", average.SubjectId)
            };

            string query = "EXEC AddAverage @AverageGrade, @IsFinal, @StudentId, @SubjectId";

            _dbContext.Database.ExecuteSqlRaw(query, parameters);
        }

        public void DeleteAverage(Average average)
        {
            var parameter = new SqlParameter("@AverageId", average.AverageId);

            string query = "EXEC DeleteAverage @AverageId";

            _dbContext.Database.ExecuteSqlRaw(query, parameter);
        }

        public void UpdateAverage(Average average, int id)
        {
            var parameterId = new SqlParameter("@Id", id);
            var parameterAverageGrade = new SqlParameter("@AverageGrade", average.AverageGrade);
            var parameterIsFinal = new SqlParameter("@IsFinal", average.IsFinal);

            string query = "EXEC UpdateAverage @Id, @AverageGrade, @IsFinal";

            _dbContext.Database.ExecuteSqlRaw(query, parameterId, parameterAverageGrade, parameterIsFinal);
        }
    }
}
