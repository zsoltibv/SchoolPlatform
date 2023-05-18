using SchoolPlatform.DAL;
using SchoolPlatform.Models;
using SchoolPlatform.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using SchoolPlatform.Views.Professor;

namespace SchoolPlatform.ViewModels
{
    public class ProfessorClassSubjectViewModel : BaseNotification
    {
        private ClassSubjectDataAccess _classSubjectDataAccess;
        private StudentDataAccess _studentDataAccess;

        public ClassSubject SelectedClassSubject { get; set; }
        public ObservableCollection<ClassSubject> ClassSubjects { get; set; }

        private ObservableCollection<Student> _students;
        public ObservableCollection<Student> Students
        {
            get { return _students; }
            set
            {
                _students = value;
                NotifyPropertyChanged(nameof(Students));
            }
        }

        public ProfessorClassSubjectViewModel()
        {
            _classSubjectDataAccess = new ClassSubjectDataAccess();
            _studentDataAccess = new StudentDataAccess();
            ClassSubjects = new ObservableCollection<ClassSubject>(_classSubjectDataAccess.GetProfessorSubjects(LoggedIn.Professor.ProfessorId));
        }

        public void RetrieveStudentList()
        {
            List<Student> matchingEntries = _studentDataAccess
                .GetAllStudents()
                .Where(st => st.ClassId == SelectedClassSubject.ClassId)
                .ToList();

            Students = new ObservableCollection<Student>(matchingEntries);
        }

        public void OpenGradesWindow(object param)
        {
            Views.Professor.ManageGrades window = new Views.Professor.ManageGrades();
            window.ShowDialog();
        }

        public ICommand OpenManageGradesWindowCommnad => new RelayCommand<object>(OpenGradesWindow);
    }
}
