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

namespace SchoolPlatform.Views.ClassMaster
{
    /// <summary>
    /// Interaction logic for ManageAbsence.xaml
    /// </summary>
    public partial class MotivateAbsences : Window
    {
        private AbsenceViewModel _absenceViewModel;

        public MotivateAbsences(Models.Student CurrentStudent)
        {
            InitializeComponent();
            _absenceViewModel = new AbsenceViewModel(CurrentStudent); 
            DataContext  = _absenceViewModel;
        }

        public void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _absenceViewModel.IsJustified = _absenceViewModel.SelectedAbsence.IsJustified ?? false; 
        }
    }
}
