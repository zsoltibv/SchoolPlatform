using SchoolPlatform.DAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolPlatform.Models;
using System.Windows.Input;

namespace SchoolPlatform.ViewModels
{
    public class ProfessorClassSubjectViewModel
    {
        private ClassDataAccess _classDataAccess;
        private ClassSubjectDataAccess _classSubjectDataAccess;
        private ProfessorClassSubjectDataAccess _professorClassSubjectDataAccess;
        
        public ProfessorClassSubject SelectedProfessorClassSubjet { get;set; }
        public ProfessorClassSubject NewProfessorClassSubject { get; set; }

        public ObservableCollection<ProfessorClassSubject> ProfessorClassSubjects { get; set; }
        public ObservableCollection<Class> Classes { get; set; }
        public ObservableCollection<ClassSubjectDataAccess> Subjects { get; set; }

        public Professor SelectedProfessor { get; set; }
        
        public ProfessorClassSubjectViewModel(Professor selectedProfessor) {  
            _professorClassSubjectDataAccess = new ProfessorClassSubjectDataAccess();
            _classDataAccess = new ClassDataAccess();
            _classSubjectDataAccess = new ClassSubjectDataAccess();   

            SelectedProfessor = selectedProfessor;
            ProfessorClassSubjects = new ObservableCollection<ProfessorClassSubject>(_professorClassSubjectDataAccess.GetProfessorSubjects(SelectedProfessor.ProfessorId));
            Classes = new ObservableCollection<Class>(_classDataAccess.GetAllClasses());
            //Subjects = new ObservableCollection<ClassSubjectDataAccess>(_classSubjectDataAccess.GetClassSubjects());
        }

        public void AddOrEditClassSubject(object param)
        {

        }

        public void RemoveClassSubject(object param)
        {

        }

        public void FillInData()
        {

        }

        public ICommand AddOrEditClassSubjectCommand => new RelayCommand<object>(AddOrEditClassSubject);
        public ICommand DeleteClassSubjectCommand => new RelayCommand<object>(RemoveClassSubject);
    }
}
