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

namespace SchoolPlatform.Views.Admin
{
    /// <summary>
    /// Interaction logic for DashboardView.xaml
    /// </summary>
    public partial class DashboardView : Window
    {
        AdminDashboardViewModel _adminDashboardVM;
        public DashboardView()
        {
            InitializeComponent();
            _adminDashboardVM = new AdminDashboardViewModel();
            DataContext = _adminDashboardVM;
        }
    }
}
