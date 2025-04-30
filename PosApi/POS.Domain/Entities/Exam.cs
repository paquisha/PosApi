using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Entities
{
    [Table("Exams")]
    public class Exam : BaseEntity
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [ForeignKey("ExamType")]
        public int ExamTypeId { get; set; }
        public virtual ExamType? ExamType { get; set; }
        [InverseProperty("Exam")]
        public virtual ICollection<MedicalExam> MedicalExams { get; set; } = new List<MedicalExam>();

        [InverseProperty("Exams")]
        public virtual ICollection<MedicalRecord> MedicalRecords { get; set; } = new List<MedicalRecord>();


        public Exam()
        {
            Name = string.Empty;
        }
    }
}
