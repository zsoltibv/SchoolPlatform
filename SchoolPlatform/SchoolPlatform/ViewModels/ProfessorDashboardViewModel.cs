using SchoolPlatform.DAL;
using SchoolPlatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolPlatform.ViewModels
{
    public class ProfessorDashboardViewModel : BaseNotification
    {
        private ProfessorClassSubjectViewModel _professorClassSubjectViewModel;
        public ProfessorClassSubjectViewModel ProfessorClassSubjectViewModel
        {
            get { return _professorClassSubjectViewModel; }
            set
            {
                _professorClassSubjectViewModel = value;
                NotifyPropertyChanged(nameof(ProfessorClassSubjectViewModel));
            }
        }

        public ProfessorDashboardViewModel() {
            _professorClassSubjectViewModel = new ProfessorClassSubjectViewModel();
        }
    }
}
