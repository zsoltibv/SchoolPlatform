using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolPlatform.Models
{
    public class Absence : BaseNotification
    {
        [Key]
        private int _absenceId;
        public int AbsenceId
        {
            get { return _absenceId; }
            set
            {
                _absenceId = value;
                NotifyPropertyChanged("AbsenceId");
            }
        }

        private DateTime _absenceDate;
        public DateTime AbsenceDate
        {
            get { return _absenceDate; }
            set
            {
                _absenceDate = value;
                NotifyPropertyChanged("AbsenceDate");
            }
        }

        private bool? _isJustified;
        public bool? IsJustified
        {
            get { return _isJustified; }
            set
            {
                _isJustified = value;
                NotifyPropertyChanged("IsJustified");
            }
        }

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

        [ForeignKey("StudentId")]
        private Student _student;
        public Student Student
        {
            get { return _student; }
            set
            {
                _student = value;
                NotifyPropertyChanged("Student");
            }
        }

        private int _subjectId;
        public int SubjectId
        {
            get { return _subjectId; }
            set
            {
                _studentId = value;
                NotifyPropertyChanged("SubjectId");
            }
        }

        [ForeignKey("SubjectId")]
        private Subject _subject;
        public Subject Subject
        {
            get { return _subject; }
            set
            {
                _subject = value;
                NotifyPropertyChanged("Subject");
            }
        }
    }
}
