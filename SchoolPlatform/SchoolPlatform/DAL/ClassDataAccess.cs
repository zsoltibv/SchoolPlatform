using SchoolPlatform.Data;
using SchoolPlatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolPlatform.DAL
{
    public class ClassDataAccess
    {
        private readonly DataContext _dbContext;
        public ClassDataAccess()
        {
            _dbContext = DataContextSingleton.Instance;
        }

        public List<Class> GetAllClasses()
        {
            return _dbContext.Classes.ToList();
        }

        public Class GetClassById(int id)
        {
            return _dbContext.Classes.FirstOrDefault(u => u.ClassId == id);
        }

        public void AddClass(Class c)
        {
            _dbContext.Classes.Add(c);
            _dbContext.SaveChanges();
        }

        public void DeleteClass(Class c)
        {
            _dbContext.Classes.Remove(c);
            _dbContext.SaveChanges();
        }

        public void UpdateClass(Class c, int id)
        {
            var dbEntity = GetClassById(id);

            if (dbEntity != null)
            {
                dbEntity.Specialization = c.Specialization;
                dbEntity.SpecializationId = c.SpecializationId;
                dbEntity.YearOfStudy = c.YearOfStudy;
                dbEntity.YearOfStudyId = c.YearOfStudyId;
                dbEntity.ClassMaster = c.ClassMaster;
                dbEntity.ClassMasterId = c.ClassMasterId;
                _dbContext.SaveChanges();
            }
        }
    }
}
