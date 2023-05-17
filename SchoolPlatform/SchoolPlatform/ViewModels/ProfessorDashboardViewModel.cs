using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolPlatform.ViewModels
{
    public class ProfessorDashboardViewModel : BaseNotification
    {
        private StudentViewModel _studentViewModel;
        public StudentViewModel StudentViewModel
        {
            get { return _studentViewModel; }
            set
            {
                _studentViewModel = value;
                NotifyPropertyChanged(nameof(StudentViewModel));
            }
        }

        public ProfessorDashboardViewModel() { }
    }
}
