using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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

        private DateTime? _selectedDate = DateTime.Today;
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
            Absences = new ObservableCollection<Absence>(_absenceDataAccess.GetAllAbsences(CurrentStudent.StudentId, CurrentClassSubject.Subject.SubjectId));
        }

        public void AddAbsence(object param)
        {
            Absence absence = new Absence {
                AbsenceDate = SelectedDate.Value.Date,
                IsJustified = IsJustified,
                StudentId = CurrentStudent.StudentId,
                Student = CurrentStudent,
                SubjectId = CurrentClassSubject.Subject.SubjectId,
                Subject = CurrentClassSubject.Subject,
            };
            _absenceDataAccess.AddAbsence(absence);
            Absences.Add(absence);
        }

        public void DeleteAbsence(object param)
        {
            _absenceDataAccess.DeleteAbsence(SelectedAbsence);
            var objectToRemove = Absences.FirstOrDefault(obj => obj == SelectedAbsence);
            Absences.Remove(objectToRemove);
        }

        public void UpdateAbsence(object param)
        {
            SelectedAbsence.AbsenceDate = SelectedDate.Value;
            SelectedAbsence.IsJustified = IsJustified;
            _absenceDataAccess.UpdateAbsence(SelectedAbsence, SelectedAbsence.AbsenceId);
        }

        public void FillInData()
        {
            SelectedDate = SelectedAbsence.AbsenceDate;
            IsJustified = (bool)SelectedAbsence.IsJustified;
        }

        public ICommand AddAbsenceCommand => new RelayCommand<object>(AddAbsence);
        public ICommand DeleteAbsenceCommand => new RelayCommand<object>(DeleteAbsence);
        public ICommand UpdateAbsenceCommand => new RelayCommand<object>(UpdateAbsence);
    }
}
