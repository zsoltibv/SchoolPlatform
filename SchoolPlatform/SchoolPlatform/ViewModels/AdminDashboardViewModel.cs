using SchoolPlatform.DAL;
using SchoolPlatform.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolPlatform.ViewModels
{
    public class AdminDashboardViewModel : BaseNotification
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

        public AdminDashboardViewModel()
        {
            _studentViewModel = new StudentViewModel();
        }
    }
}
