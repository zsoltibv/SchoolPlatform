using SchoolPlatform.Models;
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

namespace SchoolPlatform.Views.ClassMaster
{
    /// <summary>
    /// Interaction logic for ViewAverages.xaml
    /// </summary>
    public partial class ViewAverages : Window
    {
        AverageViewModel _averageViewModel;
        public ViewAverages(Models.Student selectedStudent)
        {
            InitializeComponent();
            _averageViewModel = new AverageViewModel(selectedStudent);
            DataContext = _averageViewModel;
        }
    }
}
