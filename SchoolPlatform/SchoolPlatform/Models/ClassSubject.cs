using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolPlatform.Models
{
    public class ClassSubject : BaseNotification
    {
        [Key]
        private int _classSubjectId;
        public int ClassSubjectId
        {
            get { return _classSubjectId; }
            set
            {
                _classSubjectId = value;
                NotifyPropertyChanged("ClassSubjectId");
            }
        }

        private int _classId;
        public int ClassId
        {
            get { return _classId; }
            set
            {
                _classId = value;
                NotifyPropertyChanged("ClassId");
            }
        }

        [ForeignKey("ClassId")]
        public Class Class { get; set; }

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
        public Subject Subject { get; set; }
    }
}
