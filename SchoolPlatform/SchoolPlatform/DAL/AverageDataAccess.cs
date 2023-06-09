﻿using Microsoft.Data.SqlClient;
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

        public Average GetAverage(int studentId, int subjectId)
        {
            var studentIdParam = new SqlParameter("@StudentId", studentId);
            var subjectIdParam = new SqlParameter("@SubjectId", subjectId);

            string query = "EXEC GetAverages @StudentId, @SubjectId";

            var averages = _dbContext.Averages.FromSqlRaw(query, studentIdParam, subjectIdParam).AsEnumerable();
            return averages.FirstOrDefault();
        }

        public List<Average> GetAverages(int studentId)
        {
            var studentIdParam = new SqlParameter("@StudentId", studentId);

            string query = "EXEC GetAllAverages @StudentId";

            var averages = _dbContext.Averages
                .FromSqlRaw(query, studentIdParam)
                .ToList();

            var subjectIds = averages.Select(a => a.SubjectId).Distinct().ToList();

            var subjects = _dbContext.Subjects
                .Where(s => subjectIds.Contains(s.SubjectId))
                .ToList();

            foreach (var average in averages)
            {
                average.Subject = subjects.FirstOrDefault(s => s.SubjectId == average.SubjectId);
            }

            return averages;
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
