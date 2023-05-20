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
using SchoolPlatform.Models;

namespace SchoolPlatform.Views.Professor
{
    /// <summary>
    /// Interaction logic for ManageGrades.xaml
    /// </summary>
    public partial class ManageGrades : Window
    {
        GradeViewModel _gradeViewModel;
        public ManageGrades(ClassSubject currentClassSubject, Student currentStudent)
        {
            InitializeComponent();
            _gradeViewModel = new GradeViewModel(currentClassSubject, currentStudent);
            DataContext = _gradeViewModel;
        }

        public void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_gradeViewModel.SelectedGrade != null)
            {
                _gradeViewModel.InputGrade = _gradeViewModel.SelectedGrade.GradeValue.ToString();
                _gradeViewModel.IsFinalExam = _gradeViewModel.SelectedGrade.IsFinalExam;
            }
        }
    }
}
