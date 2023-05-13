using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace SchoolPlatform.Models
{
    public class Student : BaseNotification
    {
        [Key]
        private int _studentId;
        public int StudentId
        {
            get { return _studentId; }
            set
            {
                _studentId = value;
                NotifyPropertyChanged("StudentId");
            }
        }

        private string _studentName;
        public string StudentName
        {
            get { return _studentName; }
            set
            {
                _studentName = value;
                NotifyPropertyChanged("StudentName");
            }
        }

        private int _userId;
        public int UserId
        {
            get { return _userId; }
            set
            {
                _userId = value;
                NotifyPropertyChanged("UserId");
            }
        }

        [ForeignKey("UserId")]
        public User User { get; set; }

        private int _yearOfStudyId;
        public int YearOfStudyId
        {
            get { return _yearOfStudyId; }
            set
            {
                _yearOfStudyId = value;
                NotifyPropertyChanged("YearOfStudyId");
            }
        }

        [ForeignKey("YearOfStudyId")]
        private YearOfStudy _yearOfStudy;
        public YearOfStudy YearOfStudy
        {
            get { return _yearOfStudy; }
            set
            {
                _yearOfStudy = value;
                NotifyPropertyChanged("YearOfStudy");
            }
        }

        private int _specializationId;
        public int SpecializationId
        {
            get { return _specializationId; }
            set
            {
                _specializationId = value;
                NotifyPropertyChanged("SpecializationId");
            }
        }

        [ForeignKey("SpecializationId")]
        private Specialization _specialization;
        public Specialization Specialization
        {
            get { return _specialization; }
            set
            {
                _specialization = value;
                NotifyPropertyChanged("Specialization");
            }
        }

        public Student()
        {
        }

        public Student(int userId, string studentName)
        {
            UserId = userId;
            StudentName = studentName;
        }
    }
}
