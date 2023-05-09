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
using SchoolPlatform.ViewModels;

namespace SchoolPlatform.Views.Student
{
    /// <summary>
    /// Interaction logic for AddOrEditStudent.xaml
    /// </summary>
    public partial class AddOrEditStudent : Window
    {
        StudentViewModel _studentVM;
        public AddOrEditStudent()
        {
            InitializeComponent();
            _studentVM = new StudentViewModel();
        }

        private void AddStudent_ButtonClick(object sender, RoutedEventArgs e)
        {
            _studentVM.AddStudent(
                   txtUsername.Text,
                   txtPassword.Text,
                   txtFullName.Text
            );
            MessageBox.Show("Student Added succesfully!");
            this.Close();
        }
    }
}
