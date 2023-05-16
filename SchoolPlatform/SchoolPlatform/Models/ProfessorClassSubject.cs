using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolPlatform.Models
{
    public class ProfessorClassSubject : BaseNotification
    {
        [Key]
        private int _professorClassSubjectId;
        public int ProfessorClassSubjectId
        {
            get { return _professorClassSubjectId; }
            set
            {
                _professorClassSubjectId = value;
                NotifyPropertyChanged("ProfessorClassSubjectId");
            }
        }

        private int _professorId;
        public int ProfessorId
        {
            get { return _professorId; }
            set
            {
                _professorId = value;
                NotifyPropertyChanged("ProfessorId");
            }
        }

        [ForeignKey("ProfessorId")]
        private Professor _professor;
        public Professor Professor
        {
            get { return _professor; }
            set
            {
                _professor = value;
                NotifyPropertyChanged("Professor");
            }
        }
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

        [ForeignKey("ClassSubjectId")]
        private ClassSubject _classSubject;
        public ClassSubject ClassSubject
        {
            get { return _classSubject; }
            set
            {
                _classSubject = value;
                NotifyPropertyChanged("ClassSubject");
            }
        }

        public ProfessorClassSubject() { }
    }
}
