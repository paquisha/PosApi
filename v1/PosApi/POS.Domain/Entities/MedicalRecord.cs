using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Entities
{
    [Table("MedicalRecords")]
    public class MedicalRecord : BaseEntity
    {
        [Required]
        [StringLength(200)]
        public string Reason { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? CurrentIllness { get; set; }
        public bool Done { get; set; } = false;
        public bool Canceled { get; set; } = false;
        // Relaciones uno-a-uno
        public virtual Rpe? Rpe { get; set; }
        public virtual Cros? Cros { get; set; }
        public virtual VitalSign? VitalSign { get; set; }
        // Relaciones muchos-a-muchos usando tablas intermedias
        [InverseProperty("MedicalRecord")]
        public virtual ICollection<MedicalExam> MedicalExams { get; set; } = new List<MedicalExam>();
        [InverseProperty("MedicalRecord")]
        public virtual ICollection<Diagnostic> Diagnostics { get; set; } = new List<Diagnostic>();
        [InverseProperty("MedicalRecords")]
        public virtual ICollection<Exam> Exams { get; set; } = new List<Exam>();

        [InverseProperty("MedicalRecords")]
        public virtual ICollection<Disease> Diseases { get; set; } = new List<Disease>();
        // Relaciones directas
        [Required]
        [ForeignKey(nameof(Medic))]
        public int MedicId { get; set; }
        public virtual Medic? Medic { get; set; }
        [Required]
        [ForeignKey(nameof(Patient))]
        public int PatientId { get; set; }
        public virtual Patient? Patient { get; set; }
        public MedicalRecord()
        {
            Reason = string.Empty;
        }
    }
}
