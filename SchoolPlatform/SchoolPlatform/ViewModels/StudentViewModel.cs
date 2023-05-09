using SchoolPlatform.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolPlatform.Models;

namespace SchoolPlatform.ViewModels
{
    public class StudentViewModel
    {
        UserDataAccess _userDataAccess;
        StudentDataAccess _studentDataAccess;
        public StudentViewModel()
        {
            _userDataAccess = new UserDataAccess();
            _studentDataAccess = new StudentDataAccess();
        }

        public void AddStudent(string username, string password, string fullName)
        {
            User user = new User(username, password, UserType.Student);
            Student student = new Student(user.UserId, fullName);

            _userDataAccess.AddUser(user);
            _studentDataAccess.AddStudent(student);
        }
    }
}
