using SchoolPlatform.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolPlatform.Models;
using System.Collections.ObjectModel;
using System.Windows.Forms;
using System.Windows.Input;

namespace SchoolPlatform.ViewModels
{
    public class StudentViewModel : BaseNotification
    {
        private UserDataAccess _userDataAccess; 
        private StudentDataAccess _studentDataAccess;

        private ObservableCollection<StudentWithUser> _studentsWithUser;
        public ObservableCollection<StudentWithUser> StudentsWithUser
        {
            get { return _studentsWithUser; }
            set
            {
                _studentsWithUser = value;
                NotifyPropertyChanged("StudentsWithUser");
            }
        }

        public StudentViewModel()
        {
            _userDataAccess = new UserDataAccess();
            _studentDataAccess = new StudentDataAccess();
            StudentsWithUser = new ObservableCollection<StudentWithUser>(_studentDataAccess.GetStudentsWithUser());
        }

        public void AddStudent(string username, string password, string fullName)
        {
            User user = new User(username, password, UserType.Student);
            _userDataAccess.AddUser(user);

            Student student = new Student(user.UserId, fullName);
            _studentDataAccess.AddStudent(student);

            StudentWithUser studentWithUser = new StudentWithUser(student, user);
            StudentsWithUser.Add(studentWithUser);
        }
    }
}
