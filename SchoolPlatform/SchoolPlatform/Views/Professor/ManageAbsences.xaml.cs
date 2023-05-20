using SchoolPlatform.Models;
using SchoolPlatform.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SchoolPlatform.Views.Professor
{
    /// <summary>
    /// Interaction logic for ManageAbsences.xaml
    /// </summary>
    public partial class ManageAbsences : Window
    {
        private AbsenceViewModel _absenceViewModel;
        public ManageAbsences(ClassSubject currentClassSubject, Student currentStudent)
        {
            InitializeComponent();
            _absenceViewModel = new AbsenceViewModel(currentClassSubject, currentStudent);
            DataContext = _absenceViewModel;
        }

        public void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_absenceViewModel.SelectedAbsence != null)
            {
                
            }
        }
    }
}
