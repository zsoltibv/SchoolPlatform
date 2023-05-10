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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

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

        public string UserName { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }

        public StudentWithUser SelectedStudent { get; set; }

        public StudentViewModel()
        {
            _userDataAccess = new UserDataAccess();
            _studentDataAccess = new StudentDataAccess();
            StudentsWithUser = new ObservableCollection<StudentWithUser>(_studentDataAccess.GetStudentsWithUser());
        }

        public void AddStudent(object param)
        {
            User user = new User(UserName, Password, UserType.Student);
            _userDataAccess.AddUser(user);

            Student student = new Student(user.UserId, FullName);
            _studentDataAccess.AddStudent(student);

            StudentsWithUser.Add(new StudentWithUser(student, user));
        }

        public void DeleteStudent(object param)
        {
            if(SelectedStudent != null) { 
                int idToRemove = SelectedStudent.User.UserId;

                User user = _userDataAccess.GetUserById(idToRemove);
                _userDataAccess.DeleteUser(user);
            }
            else
            {
                MessageBox.Show("No selected entity!");
            }

            RefreshStudentList();
        }

        public void RefreshStudentList()
        {
            var list = _studentDataAccess.GetStudentsWithUser();
            StudentsWithUser.Clear();
            foreach (var item in list)
            {
                StudentsWithUser.Add(item);
            }
        }

        private ICommand _addStudentCommand;
        public ICommand AddStudentCommand
        {
            get
            {
                if (_addStudentCommand == null)
                {
                    _addStudentCommand = new RelayCommand<object>(AddStudent);
                }
                return _addStudentCommand;
            }
        }

        private ICommand _deleteStudentCommand;
        public ICommand DeleteStudentCommand
        {
            get
            {
                if (_deleteStudentCommand == null)
                {
                    _deleteStudentCommand = new RelayCommand<object>(DeleteStudent);
                }
                return _deleteStudentCommand;
            }
        }
    }
}
