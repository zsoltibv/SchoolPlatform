using SchoolPlatform.DAL;
using SchoolPlatform.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolPlatform.ViewModels
{
    public class AdminDashboardViewModel : INotifyPropertyChanged
    {
        UserDataAccess _userDataAccess;
        private ObservableCollection<User> users;
        public ObservableCollection<User> Users
        {
            get { return users; }
            set
            {
                users = value;
                NotifyPropertyChanged();
            }
        }

        public AdminDashboardViewModel()
        {
            _userDataAccess = new UserDataAccess();
            Users = new ObservableCollection<User>(_userDataAccess.GetAllUsers());
        }
    }
}
