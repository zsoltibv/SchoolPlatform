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

        public string UserName { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public ObservableCollection<YearOfStudy> YearOfStudies { get; set; }
        public YearOfStudy SelectedYearOfStudy { get; set; }
        public ObservableCollection<Specialization> Specializations { get; set; }
        public Specialization SelectedSpecialization { get; set; }
        public bool EditMode { get; set; }

        public Student NewStudent { get; set; }
        public Student SelectedStudent { get; set; }

        public StudentViewModel()
        {
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

                Students.Add(student);
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
                _studentDataAccess.UpdateStudent(student, SelectedStudent.StudentId);

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
            var list = _studentDataAccess.GetAllStudents();
            Students.Clear();
            foreach (var item in list)
            {
                Students.Add(item);
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
