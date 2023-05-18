using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolPlatform.Models
{
    public class Grade : BaseNotification
    {
        [Key]
        private int _gradeId;
        public int GradeId
        {
            get { return _gradeId; }
            set
            {
                _gradeId = value;
                NotifyPropertyChanged("GradeId");
            }
        }

        private float _gradeValue;
        public float GradeValue
        {
            get { return _gradeValue; }
            set
            {
                _gradeValue = value;
                NotifyPropertyChanged("GradeValue");
            }
        }

        private bool _isFinalExam;
        public bool IsFinalExam
        {
            get { return _isFinalExam; }
            set
            {
                _isFinalExam = value;
                NotifyPropertyChanged("IsFinalExam");
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
