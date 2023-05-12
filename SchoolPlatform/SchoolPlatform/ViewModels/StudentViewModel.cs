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
        private SpecializationDataAccess _specializationDataAccess;
        private YearDataAccess _yearDataAccess;

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
        public ObservableCollection<YearOfStudy> YearOfStudies { get; set; }
        public YearOfStudy SelectedYearOfStudy { get; set; }
        public ObservableCollection<Specialization> Specializations { get; set; }
        public Specialization SelectedSpecialization { get; set; }
        public bool EditMode { get; set; }

        public StudentWithUser SelectedStudent { get; set; }

        public StudentViewModel()
        {
            _userDataAccess = new UserDataAccess();
            _studentDataAccess = new StudentDataAccess();
            _yearDataAccess = new YearDataAccess();
            _specializationDataAccess = new SpecializationDataAccess();
            StudentsWithUser = new ObservableCollection<StudentWithUser>(_studentDataAccess.GetStudentsWithUser());
            YearOfStudies = new ObservableCollection<YearOfStudy>(_yearDataAccess.GetAllYearsOfStudy());
            Specializations = new ObservableCollection<Specialization>(_specializationDataAccess.GetAllSpecializations());
        }

        public void AddOrEditStudent(object param)
        {
            if (!EditMode)
            {
                User user = new User(UserName, Password, UserType.Student);
                _userDataAccess.AddUser(user);

                Student student = new Student
                {
                    UserId = user.UserId,
                    StudentName = FullName,
                    YearOfStudyId = SelectedYearOfStudy.YearOfStudyId,
                    SpecializationId = SelectedSpecialization.SpecializationId,
                };
                _studentDataAccess.AddStudent(student);

                StudentsWithUser.Add(new StudentWithUser(student, user));
            }
            else if(SelectedStudent != null)
            {
                User user = new User(UserName, Password, UserType.Student);
                Student student = new Student
                {
                    UserId = user.UserId,
                    StudentName = FullName,
                    YearOfStudyId = SelectedYearOfStudy.YearOfStudyId,
                    SpecializationId = SelectedSpecialization.SpecializationId
                };

                _userDataAccess.UpdateUser(user, SelectedStudent.User.UserId);
                _studentDataAccess.UpdateStudent(student, SelectedStudent.Student.StudentId);

                RefreshStudentList();
            }
            else
            {
                MessageBox.Show("No selected entity!");
            }
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

        private ICommand _addOrEditStudentCommand;
        public ICommand AddOrEditStudentCommand
        {
            get
            {
                if (_addOrEditStudentCommand == null)
                {
                    _addOrEditStudentCommand = new RelayCommand<object>(AddOrEditStudent);
                }
                return _addOrEditStudentCommand;
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
