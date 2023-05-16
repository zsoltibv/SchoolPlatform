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
    /// Interaction logic for ProfessorClassSubjectView.xaml
    /// </summary>
    public partial class ProfessorClassSubjectView : Window
    {
        ProfessorClassSubjectViewModel _professorClassSubjectViewModel;
        public ProfessorClassSubjectView(Models.Professor selectedProfessor)
        {
            InitializeComponent();
            _professorClassSubjectViewModel = new ProfessorClassSubjectViewModel(selectedProfessor);
            DataContext = _professorClassSubjectViewModel;
        }
    }
}
