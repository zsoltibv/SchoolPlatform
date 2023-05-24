using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SchoolPlatform.DAL;
using SchoolPlatform.Models;
using SchoolPlatform.Service;
using SchoolPlatform.Views.Professor;
using SchoolPlatform.Views.ClassMaster;

namespace SchoolPlatform.ViewModels
{
    public class ClassMasterDashboardViewModel : BaseNotification
    {
        StudentDataAccess _studentDataAccess;
        ClassDataAccess _classDataAccess;

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

        public Student SelectedStudent { get; set; }
        public Class ProfessorClass { get; set; }

        public ClassMasterDashboardViewModel()
        {
            _studentDataAccess = new StudentDataAccess();
            _classDataAccess = new ClassDataAccess();

            ProfessorClass = _classDataAccess.GetProfessorClass(LoggedIn.Professor.ProfessorId);

            List<Student> matchingEntries = _studentDataAccess
                .GetAllStudents()
                .Where(st => st.ClassId == ProfessorClass.ClassId)
                .ToList();

            Students = new ObservableCollection<Student>(matchingEntries);
        }

        public void OpenAbsencesWindow(object param)
        {
            MotivateAbsences window = new MotivateAbsences(SelectedStudent);
            window.ShowDialog();
        }

        public void OpenAveragesWindow(object param)
        {
            ViewAverages window = new ViewAverages(SelectedStudent); window.ShowDialog();   
        }

        public ICommand OpenViewAveragesWindowCommnad => new RelayCommand<object>(OpenAveragesWindow);
        public ICommand OpenMotivateAbsencesWindowCommand => new RelayCommand<object>(OpenAbsencesWindow);
    }
}
