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
    public class AbsenceViewModel : BaseNotification
    {
        private AbsenceDataAccess _absenceDataAccess;

        private ObservableCollection<Absence> _absences;
        public ObservableCollection<Absence> Absences
        {
            get { return _absences; }
            set
            {
                _absences = value;
                NotifyPropertyChanged("Grades");
            }
        }

        public Absence SelectedAbsence {  get; set; }

        private DateTime? _selectedDate;
        public DateTime? SelectedDate
        {
            get { return _selectedDate; }
            set
            {
                _selectedDate = value;
                NotifyPropertyChanged("SelectedDate");
            }
        }

        private bool _isJustified;
        public bool IsJustified
        {
            get { return _isJustified; }
            set
            {
                _isJustified = value;
                NotifyPropertyChanged("IsJustified");
            }
        }

        public ClassSubject CurrentClassSubject { get; set; }
        public Student CurrentStudent { get; set; }

        public AbsenceViewModel(ClassSubject currentClassSubject, Student currentStudent) { 
            CurrentClassSubject = currentClassSubject;
            CurrentStudent = currentStudent;    
            _absenceDataAccess = new AbsenceDataAccess();
        }

        public void AddAbsence(object param)
        {
            Console.WriteLine(SelectedDate);
        }

        public void DeleteAbsence(object param)
        {

        }

        public void UpdateAbsence(object param)
        {

        }

        public void FillInData()
        {

        }

        public ICommand AddAbsenceCommand => new RelayCommand<object>(AddAbsence);
        public ICommand DeleteAbsenceCommand => new RelayCommand<object>(DeleteAbsence);
        public ICommand UpdateAbsenceCommand => new RelayCommand<object>(UpdateAbsence);
    }
}
