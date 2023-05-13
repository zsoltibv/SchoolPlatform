using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolPlatform.Models
{
    public class Class : BaseNotification
    {
        [Key]
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
        public Specialization Specialization { get; set; }

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
        public YearOfStudy YearOfStudy { get; set; }

        public Class() { }
    }
}
