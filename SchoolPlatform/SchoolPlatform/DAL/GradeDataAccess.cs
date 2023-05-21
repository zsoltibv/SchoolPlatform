using SchoolPlatform.Data;
using SchoolPlatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolPlatform.DAL
{
    public class GradeDataAccess
    {
        private readonly DataContext _dbContext;
        public GradeDataAccess()
        {
            _dbContext = DataContextSingleton.Instance;
        }

        public List<Grade> GetAllGrades(int studentId, int subjectId)
        {
            return _dbContext.Grades
                .Where(g => g.Student.StudentId == studentId)
                .Where(g => g.Subject.SubjectId == subjectId)
                .ToList();
        }

        public Grade GetGradeById(int id)
        {
            return _dbContext.Grades.FirstOrDefault(u => u.GradeId == id);
        }

        public void AddGrade(Grade grade)
        {
            _dbContext.Grades.Add(grade);
            _dbContext.SaveChanges();
        }

        public void DeleteGrade(Grade grade)
        {
            _dbContext.Grades.Remove(grade);
            _dbContext.SaveChanges();
        }

        public void UpdateGrade(Grade grade, int id)
        {
            var dbEntity = GetGradeById(id);

            if (dbEntity != null)
            {
                dbEntity.GradeValue = grade.GradeValue;
                _dbContext.SaveChanges();
            }
        }
    }
}
