using SchoolPlatform.Data;
using SchoolPlatform.Views.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolPlatform.Models;
using Microsoft.EntityFrameworkCore;
using SchoolPlatform.ViewModels;
using System.Runtime.Remoting.Contexts;
using System.Collections.ObjectModel;

namespace SchoolPlatform.DAL
{
    public class StudentDataAccess
    {
        UserDataAccess _userDataAccess;
        private readonly DataContext _dbContext;
        public StudentDataAccess()
        {
            _dbContext = DataContextSingleton.Instance;
            _userDataAccess = new UserDataAccess();
        }

        public Student GetStudentById(int id)
        {
            return _dbContext.Students.FirstOrDefault(u => u.StudentId == id);
        }

        public void AddStudent(Student student)
        {
            _dbContext.Students.Add(student);
            _dbContext.SaveChanges();
        }

        public void DeleteStudent(Student student)
        {
            _dbContext.Students.Remove(student);
            _dbContext.SaveChanges();
        }

        public void UpdateStudent(Student student, int id)
        {
            var existingStudent = GetStudentById(id);

            if (existingStudent != null)
            {
                existingStudent.StudentName = student.StudentName;
                existingStudent.SpecializationId = student.SpecializationId;
                existingStudent.YearOfStudyId = student.YearOfStudyId;  
                _dbContext.SaveChanges();
            }
        }

        public ObservableCollection<StudentWithUser> GetStudentsWithUser()
        {
            ObservableCollection<StudentWithUser> studentsWithUsers = new ObservableCollection<StudentWithUser>();
            var students = _dbContext.Students.Include(s => s.User).ToList();

            foreach (var student in students)
            {
                studentsWithUsers.Add(new StudentWithUser(student, student.User));
            }

            return studentsWithUsers;
        }
    }
}
