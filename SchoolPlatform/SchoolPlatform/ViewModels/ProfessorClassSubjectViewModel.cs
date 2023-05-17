using SchoolPlatform.DAL;
using SchoolPlatform.Models;
using SchoolPlatform.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolPlatform.ViewModels
{
    public class ProfessorClassSubjectViewModel
    {
        ClassSubjectDataAccess _classSubjectDataAccess;

        public ClassSubject SelectedClassSubject { get; set; }
        public ObservableCollection<ClassSubject> ClassSubjects { get; set; }

        public ProfessorClassSubjectViewModel()
        {
            _classSubjectDataAccess = new ClassSubjectDataAccess();
            ClassSubjects = new ObservableCollection<ClassSubject>(_classSubjectDataAccess.GetProfessorSubjects(LoggedIn.Professor.ProfessorId));
        }
    }
}
