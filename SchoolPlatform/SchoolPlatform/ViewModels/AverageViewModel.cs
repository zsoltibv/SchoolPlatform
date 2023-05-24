using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolPlatform.DAL;
using SchoolPlatform.Models;

namespace SchoolPlatform.ViewModels
{
    public class AverageViewModel : BaseNotification
    {
        private AverageDataAccess _averageDataAccess;

        public Student SelectedStudent { get; set; }

        private ObservableCollection<Average> _averages;
        public ObservableCollection<Average> Averages
        {
            get { return _averages; }
            set
            {
                _averages = value;
                NotifyPropertyChanged("Averages");
            }
        }

        public AverageViewModel(Student selectedStudent) { 
            _averageDataAccess = new AverageDataAccess();
            SelectedStudent = selectedStudent;
            Averages = new ObservableCollection<Average>(_averageDataAccess.GetAverages(SelectedStudent.StudentId)); 
        }
    }
}
