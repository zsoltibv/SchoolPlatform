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
    public class ProfessorDataAccess
    {
        private readonly DataContext _dbContext;
        public ProfessorDataAccess()
        {
            _dbContext = DataContextSingleton.Instance;
        }

        public List<Professor> GetAllProfessors()
        {
            string query = "EXEC GetAllProfessors";
            return _dbContext.Professors.FromSqlRaw(query).ToList();
        }

        public List<Professor> GetAllClassMasters()
        {
            string query = "EXEC GetAllClassMasters";
            return _dbContext.Professors.FromSqlRaw(query).ToList();
        }

        public Professor GetProfessorById(int id)
        {
            string query = "EXEC GetProfessorById @Id";
            var idParam = new SqlParameter("@Id", id);
            return _dbContext.Professors.FromSqlRaw(query, idParam).FirstOrDefault();
        }

        public void AddProfessor(Professor professor)
        {
            string query = "EXEC AddProfessor @ProfessorName, @UserId";
            var professorNameParam = new SqlParameter("@ProfessorName", professor.ProfessorName);
            var userIdParam = new SqlParameter("@UserId", professor.UserId);
            _dbContext.Database.ExecuteSqlRaw(query, professorNameParam, userIdParam);
        }

        public void DeleteProfessor(Professor professor)
        {
            string query = "EXEC DeleteProfessor @Id";
            var idParam = new SqlParameter("@Id", professor.ProfessorId);
            _dbContext.Database.ExecuteSqlRaw(query, idParam);
        }

        public void UpdateProfessor(Professor professor, int id)
        {
            string query = "EXEC UpdateProfessor @Id, @ProfessorName";
            var idParam = new SqlParameter("@Id", id);
            var professorNameParam = new SqlParameter("@ProfessorName", professor.ProfessorName);
            _dbContext.Database.ExecuteSqlRaw(query, idParam, professorNameParam);
        }
    }
}
