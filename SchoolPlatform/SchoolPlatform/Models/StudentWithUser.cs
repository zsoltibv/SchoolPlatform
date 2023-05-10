using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolPlatform.Models
{
    public class StudentWithUser : BaseNotification
    {
        private Student _student;
        private User _user;

        public Student Student
        {
            get { return _student; }
            set
            {
                _student = value;
                NotifyPropertyChanged("Student");
            }
        }

        public User User
        {
            get { return _user; }
            set
            {
                _user = value;
                NotifyPropertyChanged("User");
            }
        }

        public StudentWithUser(Student student, User user)
        {
            Student = student;
            User = user;
        }
    }
}
