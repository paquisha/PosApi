using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace POS.Domain.Entities
{
    [Table("MedicalExams")]
    [Index(nameof(MedicalRecordId), nameof(ExamId), IsUnique = true, Name = "uniqueMedExamCombination")]
    public class MedicalExam : BaseEntity
    {
        [Required]
        [ForeignKey("MedicalRecord")]
        public int MedicalRecordId { get; set; }
        [Required]
        [ForeignKey("Exam")]
        public int ExamId { get; set; }
        public virtual MedicalRecord? MedicalRecord { get; set; }
        public virtual Exam? Exam { get; set; }

        public MedicalExam()
        {

        }
    }
}
