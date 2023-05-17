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
using SchoolPlatform.ViewModels;

namespace SchoolPlatform.Views.Professor
{
    /// <summary>
    /// Interaction logic for DashboardView.xaml
    /// </summary>
    public partial class DashboardView : Window {
        private ProfessorDashboardViewModel _professorDashboardViewModel;

        public DashboardView()
        {
            InitializeComponent();
            _professorDashboardViewModel = new ProfessorDashboardViewModel();
            DataContext = _professorDashboardViewModel;
        }

        public void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _professorDashboardViewModel.ProfessorClassSubjectViewModel.RetrieveStudentList();
        }
    }
}
