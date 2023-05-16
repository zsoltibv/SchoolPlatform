using SchoolPlatform.DAL;
using SchoolPlatform.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SchoolPlatform.ViewModels
{
    public class SubjectsClassViewModel
    {
        ClassSubjectDataAccess _classSubjectDataAccess;

        public Models.Class SelectedClass { get; set;}
        public ObservableCollection<ClassSubject> ClassSubjects { get; set;}

        public SubjectsClassViewModel(Models.Class selectedClass) { 
            SelectedClass = selectedClass;
            _classSubjectDataAccess = new ClassSubjectDataAccess();
            ClassSubjects = new ObservableCollection<ClassSubject>(_classSubjectDataAccess.GetClassSubjects(selectedClass.ClassId)); ;
        }


    }
}
