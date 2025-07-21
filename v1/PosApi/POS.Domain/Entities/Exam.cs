using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Entities
{
    public class Exam : BaseEntity
    {
        public string Name { get; set; }
        public int ExamTypeId { get; set; }
        public virtual ExamType? ExamType { get; set; }
        public virtual ICollection<MedicalExam> MedicalExams { get; set; } = new List<MedicalExam>();
        public virtual ICollection<MedicalRecord> MedicalRecords { get; set; } = new List<MedicalRecord>();
        public Exam()
        {
            Name = string.Empty;
        }
    }
}
