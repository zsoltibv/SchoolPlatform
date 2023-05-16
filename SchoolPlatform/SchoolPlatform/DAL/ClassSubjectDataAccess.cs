using SchoolPlatform.Data;
using SchoolPlatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolPlatform.DAL
{
    public class ClassSubjectDataAccess
    {
        private readonly DataContext _dbContext;
        public ClassSubjectDataAccess()
        {
            _dbContext = DataContextSingleton.Instance;
        }

        public List<ClassSubject> GetClassSubjects(int id)
        {
            return _dbContext.ClassSubjects.Where(p => p.ClassId == id).ToList();
        }

        public void AddClassSubject(ClassSubject classSubject)
        {
            _dbContext.ClassSubjects.Add(classSubject);
            _dbContext.SaveChanges();
        }
    }
}
