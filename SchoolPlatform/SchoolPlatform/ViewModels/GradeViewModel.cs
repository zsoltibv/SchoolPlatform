using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SchoolPlatform.DAL;
using SchoolPlatform.Models;

namespace SchoolPlatform.ViewModels
{
    public class GradeViewModel : BaseNotification
    {
        private GradeDataAccess _gradeDataAccess;
        private SubjectDataAccess _subjectDataAccess;

        private ObservableCollection<Grade> _grades;
        public ObservableCollection<Grade> Grades
        {
            get { return _grades; }
            set
            {
                _grades = value;
                NotifyPropertyChanged("Grades");
            }
        }
        public Grade SelectedGrade { get; set; }

        public string InputGrade { get; set; }
        public bool IsFinalExam { get; set; }

        public ClassSubject CurrentClassSubject { get; set; }
        public Student CurrentStudent { get;set; }

        public GradeViewModel(ClassSubject currentClassSubject, Student currentStudent) { 
            _gradeDataAccess = new GradeDataAccess();
            _subjectDataAccess = new SubjectDataAccess();
            CurrentClassSubject = currentClassSubject;
            CurrentStudent = currentStudent;
            Grades = new ObservableCollection<Grade>(_gradeDataAccess.GetAllGrades(CurrentStudent.StudentId));
        }

        public void AddGrade(object param)
        {

        }

        public void DeleteGrade(object param)
        {

        }

        public void UpdateGrade(object param)
        {

        }

        public ICommand AddGradeCommand => new RelayCommand<object>(AddGrade);
        public ICommand DeleteGradeCommand => new RelayCommand<object>(DeleteGrade);
        public ICommand UpdateGradeCommand => new RelayCommand<object>(UpdateGrade);
    }
}
