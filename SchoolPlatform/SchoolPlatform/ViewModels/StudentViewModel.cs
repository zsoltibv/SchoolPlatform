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
        private SpecializationDataAccess _specializationDataAccess;
        private YearDataAccess _yearDataAccess;

        private ObservableCollection<Student> _students;
        public ObservableCollection<Student> Students
        {
            get { return _students; }
            set
            {
                _students = value;
                NotifyPropertyChanged("Student");
            }
        }

        public bool EditMode { get; set; }
        public User NewUser { get; set; }
        public Student NewStudent { get; set; }
        public Student SelectedStudent { get; set; }
        public ObservableCollection<YearOfStudy> YearOfStudies { get; set; }
        public ObservableCollection<Specialization> Specializations { get; set; }

        public StudentViewModel()
        {
            ResetData();
            _userDataAccess = new UserDataAccess();
            _studentDataAccess = new StudentDataAccess();
            _yearDataAccess = new YearDataAccess();
            _specializationDataAccess = new SpecializationDataAccess();
            Students = new ObservableCollection<Student>(_studentDataAccess.GetAllStudents());
            YearOfStudies = new ObservableCollection<YearOfStudy>(_yearDataAccess.GetAllYearsOfStudy());
            Specializations = new ObservableCollection<Specialization>(_specializationDataAccess.GetAllSpecializations());
        }

        public void AddOrEditStudent(object param)
        {
            if (!EditMode)
            {
                //add user
                _userDataAccess.AddUser(NewUser);
                //add student
                NewStudent.UserId = NewUser.UserId;
                NewStudent.User = NewUser;
                NewStudent.SpecializationId = NewStudent.Specialization.SpecializationId;
                NewStudent.Specialization = NewStudent.Specialization;
                NewStudent.YearOfStudyId = NewStudent.YearOfStudy.YearOfStudyId;
                NewStudent.YearOfStudy = NewStudent.YearOfStudy;
                _studentDataAccess.AddStudent(NewStudent);
                //add to ui
                Students.Add(NewStudent);
            }
            else if(SelectedStudent != null)
            {
                _userDataAccess.UpdateUser(NewUser, SelectedStudent.User.UserId);
                _studentDataAccess.UpdateStudent(NewStudent, SelectedStudent.StudentId);
            }
            else
            {
                MessageBox.Show("No selected entity!");
            }
            ResetData();
        }

        public void DeleteStudent(object param)
        {
            if(SelectedStudent != null) {
                //delete student
                _studentDataAccess.DeleteStudent(SelectedStudent);
                //delete user
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

        public void FillInData()
        {
            NewUser.UserName = SelectedStudent.User.UserName;
            NewUser.Password = SelectedStudent.User.Password;   
            NewStudent.StudentName = SelectedStudent.StudentName;
            NewStudent.Specialization = SelectedStudent.Specialization;
            NewStudent.SpecializationId = SelectedStudent.Specialization.SpecializationId;
            NewStudent.YearOfStudy = SelectedStudent.YearOfStudy;
            NewStudent.YearOfStudyId = SelectedStudent.YearOfStudy.YearOfStudyId;
        }

        public void ResetData()
        {
            NewUser = new User
            {
                UserType = UserType.Student,
            };
            NewStudent = new Student();
        }

        public void RefreshStudentList()
        {
            var list = _studentDataAccess.GetAllStudents();
            Students.Clear();
            foreach (var item in list)
            {
                Students.Add(item);
            }
        }

        public ICommand AddOrEditStudentCommand => new RelayCommand<object>(AddOrEditStudent);

        public ICommand DeleteStudentCommand => new RelayCommand<object>(DeleteStudent);
    }
}
