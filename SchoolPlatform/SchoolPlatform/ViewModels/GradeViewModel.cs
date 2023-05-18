using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SchoolPlatform.Models;

namespace SchoolPlatform.ViewModels
{
    public class GradeViewModel : BaseNotification
    {
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

        private ObservableCollection<Subject> _subjects;
        public ObservableCollection<Subject> Subjects
        {
            get { return _subjects; }
            set
            {
                _subjects = value;
                NotifyPropertyChanged("Subjects");
            }
        }
        public Subject SelectedSubject { get; set; }

        public string InputGrade { get; set; }
        public bool IsFinalExam { get; set; }

        public GradeViewModel() { }

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
