﻿using SchoolPlatform.ViewModels;
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

namespace SchoolPlatform.Views.Auth
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        LoginViewModel _loginVM;
        public LoginView()
        {
            InitializeComponent();
            _loginVM = new LoginViewModel();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _loginVM.Authenticate(this, UserNameInput.Text, PasswordInput.Password);
        }
    }
}
