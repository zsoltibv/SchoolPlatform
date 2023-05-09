using SchoolPlatform.Data;
using SchoolPlatform.Views.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolPlatform.Models;

namespace SchoolPlatform.DAL
{
    public class StudentDataAccess
    {
        private readonly DataContext _dbContext;
        public StudentDataAccess()
        {
            _dbContext = DataContextSingleton.Instance;
        }

        public void AddStudent(Student student)
        {
            _dbContext.Students.Add(student);
            _dbContext.SaveChanges();
        }
    }
}
