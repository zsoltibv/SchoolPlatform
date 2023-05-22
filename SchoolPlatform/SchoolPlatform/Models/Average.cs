using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolPlatform.Models
{
    public class Average : BaseNotification
    {
        [Key]
        private int _averageId;
        public int AverageId
        {
            get { return _averageId; }
            set
            {
                _averageId = value;
                NotifyPropertyChanged("AverageId");
            }
        }

        private float _averageGrade;
        public float AverageGrade
        {
            get { return _averageGrade; }
            set
            {
                _averageGrade = value;
                NotifyPropertyChanged("AverageGrade");
            }
        }

        private bool _isFinal;
        public bool IsFinal
        {
            get { return _isFinal; }
            set
            {
                _isFinal = value;
                NotifyPropertyChanged("IsFinal");
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
                _subjectId = value;
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
