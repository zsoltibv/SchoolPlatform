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
        UserDataAccess _userDataAccess;
        private readonly DataContext _dbContext;
        public ProfessorDataAccess()
        {
            _dbContext = DataContextSingleton.Instance;
            _userDataAccess = new UserDataAccess();
        }

        public List<Professor> GetAllProfessors()
        {
            return _dbContext.Professors.ToList();
        }

        public List<Professor> GetAllClassMasters()
        {
            return _dbContext.Professors
                .Where(p => p.User.UserType == UserType.ClassMaster)
                .ToList();
        }

        public Professor GetProfessorById(int id)
        {
            return _dbContext.Professors.FirstOrDefault(u => u.ProfessorId == id);
        }

        public void AddProfessor(Professor professor)
        {
            _dbContext.Professors.Add(professor);
            _dbContext.SaveChanges();
        }

        public void DeleteProfessor(Professor professor)
        {
            _dbContext.Professors.Remove(professor);
            _dbContext.SaveChanges();
        }

        public void UpdateProfessor(Professor professor, int id)
        {
            var dbEntity = GetProfessorById(id);

            if (dbEntity != null)
            {
                dbEntity.ProfessorName = professor.ProfessorName;
                _dbContext.SaveChanges();
            }
        }
    }
}
