using Microsoft.EntityFrameworkCore;
using SchoolPlatform.DAL;
using SchoolPlatform.Data;
using SchoolPlatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using SchoolPlatform.Views.Auth;
using System.Windows;

namespace SchoolPlatform.ViewModels
{
    public class LoginViewModel
    {
        UserDataAccess UserDataAccess;
        public LoginViewModel() {
            UserDataAccess = new UserDataAccess();
        }

        public void Authenticate(LoginView login, string username, string password)
        {
            User user = UserDataAccess.GetUserByUsernameAndPassword(username, password);
            if(user != null) {
                if (user.UserType == UserType.Administrator)
                {
                    Views.Admin.DashboardView dashboardView = new Views.Admin.DashboardView();
                    dashboardView.Show();
                    login.Close();
                }
            }
            else
            {
                MessageBox.Show("Wrong Credentials!");
            }
        }
    }
}
