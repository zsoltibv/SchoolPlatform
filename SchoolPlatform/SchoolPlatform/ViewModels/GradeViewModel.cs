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
    public class GradeViewModel : BaseNotification
    {
        private GradeDataAccess _gradeDataAccess;
        private SubjectDataAccess _subjectDataAccess;
        private AverageDataAccess _averageDataAccess;

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

        private string _inputGrade = string.Empty;
        public string InputGrade
        {
            get { return _inputGrade; }
            set
            {
                _inputGrade = value;
                NotifyPropertyChanged("InputGrade");
            }
        }
        private bool _isFinalExam;
        public bool IsFinalExam
        {
            get { return _isFinalExam; }
            set
            {
                _isFinalExam = value;
                NotifyPropertyChanged("IsFinalExam");
            }
        }
        private Average _average;
        public Average Average
        {
            get { return _average; }
            set
            {
                _average = value;
                NotifyPropertyChanged("Average");
            }
        }

        public ClassSubject CurrentClassSubject { get; set; }
        public Student CurrentStudent { get; set; }

        public GradeViewModel(ClassSubject currentClassSubject, Student currentStudent)
        {
            _gradeDataAccess = new GradeDataAccess();
            _subjectDataAccess = new SubjectDataAccess();
            _averageDataAccess = new AverageDataAccess();
            CurrentClassSubject = currentClassSubject;
            CurrentStudent = currentStudent;
            Grades = new ObservableCollection<Grade>(_gradeDataAccess.GetAllGrades(CurrentStudent.StudentId, CurrentClassSubject.Subject.SubjectId));
            Average = _averageDataAccess.GetAverage(CurrentStudent.StudentId, currentClassSubject.Subject.SubjectId);
        }

        public void AddGrade(object param)
        {
            Grade grade = new Grade
            {
                GradeValue = float.Parse(InputGrade),
                IsFinalExam = IsFinalExam,
                SubjectId = CurrentClassSubject.Subject.SubjectId,
                Subject = CurrentClassSubject.Subject,
                StudentId = CurrentStudent.StudentId,
                Student = CurrentStudent
            };

            _gradeDataAccess.AddGrade(grade);
            Grades.Add(grade);
        }

        public void DeleteGrade(object param)
        {
            _gradeDataAccess.DeleteGrade(SelectedGrade);
            var objectToRemove = Grades.FirstOrDefault(obj => obj == SelectedGrade);
            Grades.Remove(objectToRemove);
        }

        public void UpdateGrade(object param)
        {
            SelectedGrade.GradeValue = float.Parse(InputGrade);
            SelectedGrade.IsFinalExam = IsFinalExam;
            _gradeDataAccess.UpdateGrade(SelectedGrade, SelectedGrade.GradeId);
        }

        public void CalculateAverage(object param)
        {
            float averageGrade = 0;
            float finalGrade = 0;
            int numOfGrades = Grades.Count - 1;
            if (numOfGrades < 3)
            {
                MessageBox.Show("You need at least 4 grades to calculate average.");
                return;
            }
            foreach (Grade grade in Grades)
            {
                if (grade.IsFinalExam is false)
                {
                    averageGrade += grade.GradeValue;
                }
                else
                {
                    finalGrade = grade.GradeValue;
                }
            }
            averageGrade /= numOfGrades;
            if (finalGrade != 0)
            {
                if (Average == null)
                {
                    Average = new Average
                    {
                        AverageGrade = (25 * finalGrade + 75 * averageGrade) / 100,
                        IsFinal = false,
                        StudentId = CurrentStudent.StudentId,
                        Student = CurrentStudent,
                        SubjectId = CurrentClassSubject.Subject.SubjectId,
                        Subject = CurrentClassSubject.Subject,
                    };
                    _averageDataAccess.AddAverage(Average);
                }
                else
                {
                    Average.AverageGrade = (25 * finalGrade + 75 * averageGrade) / 100;
                    _averageDataAccess.UpdateAverage(Average, Average.AverageId);
                }
            }
        }

        public void DeleteAverage(object param)
        {
            _averageDataAccess.DeleteAverage(Average);
            Average = _averageDataAccess.GetAverage(CurrentStudent.StudentId, CurrentClassSubject.Subject.SubjectId);
        }

        public void FillInData()
        {
            InputGrade = SelectedGrade.GradeValue.ToString();
            IsFinalExam = SelectedGrade.IsFinalExam;
        }

        public ICommand AddGradeCommand => new RelayCommand<object>(AddGrade);
        public ICommand DeleteGradeCommand => new RelayCommand<object>(DeleteGrade);
        public ICommand UpdateGradeCommand => new RelayCommand<object>(UpdateGrade);
        public ICommand CalculateAverageCommand => new RelayCommand<object>(CalculateAverage);
        public ICommand DeleteAverageCommand => new RelayCommand<object>(DeleteAverage);
    }
}
