using SchoolPlatform.Data;
using SchoolPlatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolPlatform.DAL
{
    public class AbsenceDataAccess
    {
        private readonly DataContext _dbContext;
        public AbsenceDataAccess()
        {
            _dbContext = DataContextSingleton.Instance;
        }

        public List<Absence> GetAllAbsences(int studentId, int subjectId)
        {
            return _dbContext.Absences
                .Where(g => g.Student.StudentId == studentId)
                .Where(g => g.Subject.SubjectId == subjectId)
                .ToList();
        }

        public Absence GetAbsenceById(int id)
        {
            return _dbContext.Absences.FirstOrDefault(u => u.AbsenceId == id);
        }

        public void AddAbsence(Absence absence)
        {
            _dbContext.Absences.Add(absence);
            _dbContext.SaveChanges();
        }

        public void DeleteAbsence(Absence absence)
        {
            _dbContext.Absences.Remove(absence);
            _dbContext.SaveChanges();
        }

        public void UpdateAbsence(Absence absence, int id)
        {
            var dbEntity = GetAbsenceById(id);

            if (dbEntity != null)
            {
                dbEntity.AbsenceDate = absence.AbsenceDate;
                dbEntity.IsJustified = absence.IsJustified;
                _dbContext.SaveChanges();
            }
        }
    }
}
