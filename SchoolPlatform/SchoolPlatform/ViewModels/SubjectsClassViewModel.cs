using SchoolPlatform.DAL;
using SchoolPlatform.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace SchoolPlatform.ViewModels
{
    public class SubjectsClassViewModel
    {
        ClassSubjectDataAccess _classSubjectDataAccess;
        SubjectDataAccess _subjectDataAccess;

        public Models.Class SelectedClass { get; set;}
        public ClassSubject SelectedClassSubject { get; set; }
        public ObservableCollection<ClassSubject> ClassSubjects { get; set; }
        public ObservableCollection<Subject> Subjects { get; set; }
        public Subject SelectedSubject { get; set; }

        public SubjectsClassViewModel(Models.Class selectedClass) { 
            SelectedClass = selectedClass;
            _classSubjectDataAccess = new ClassSubjectDataAccess();
            _subjectDataAccess = new SubjectDataAccess();
            ClassSubjects = new ObservableCollection<ClassSubject>(_classSubjectDataAccess.GetClassSubjects(selectedClass.ClassId));
            Subjects = new ObservableCollection<Subject>(_subjectDataAccess.GetAllSubjects());
        }

        public void AddSubject(object param)
        {
            ClassSubject classSubject = new ClassSubject
            {
                ClassId = SelectedClass.ClassId,
                Class = SelectedClass,
                SubjectId = SelectedSubject.SubjectId,
                Subject = SelectedSubject,
            };
            _classSubjectDataAccess.AddClassSubject(classSubject);

            ClassSubjects.Add(classSubject);
        }

        public void RemoveSubject(object param)
        {
            _classSubjectDataAccess.DeleteClassSubject(SelectedClassSubject);

            var objectToRemove = ClassSubjects.FirstOrDefault(obj => obj.ClassSubjectId == SelectedClassSubject.ClassSubjectId);
            ClassSubjects.Remove(objectToRemove);
        }

        public ICommand AddSubjectCommand => new RelayCommand<object>(AddSubject);
        public ICommand RemoveSubjectCommand => new RelayCommand<object>(RemoveSubject);
    }
}
