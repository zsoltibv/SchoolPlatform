using SchoolPlatform.Data;
using SchoolPlatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolPlatform.DAL
{
    public class ProfessorClassSubjectDataAccess
    {
        private readonly DataContext _dbContext;
        public ProfessorClassSubjectDataAccess()
        {
            _dbContext = DataContextSingleton.Instance;
        }

        public List<ProfessorClassSubject> GetProfessorSubjects(int id)
        {
            return _dbContext.ProfessorClassSubjects.Where(p => p.ProfessorId == id).ToList();
        }

        public void AddProfessorSubject(ProfessorClassSubject professorClassSubject)
        {
            _dbContext.ProfessorClassSubjects.Add(professorClassSubject);
            _dbContext.SaveChanges();
        }

        public void DeleteProfessorSubject(ProfessorClassSubject professorClassSubject)
        {
            _dbContext.ProfessorClassSubjects.Remove(professorClassSubject);
            _dbContext.SaveChanges();
        }
    }
}
