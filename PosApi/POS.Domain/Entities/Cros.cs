using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Entities
{
    [Table("Cros")]
    public class Cros : BaseEntity
    {
        [Required]
        [ForeignKey("MedicalRecord")]
        public int MedicalRecordId { get; set; }

        public bool SenseOrgans { get; set; } = false;

        public bool Respiratory { get; set; } = false;

        public bool Cardiovascular { get; set; } = false;

        public bool Digestive { get; set; } = false;

        public bool Genital { get; set; } = false;

        public bool Urinary { get; set; } = false;

        public bool SkeletalMuscle { get; set; } = false;

        public bool Endocrine { get; set; } = false;

        public bool LymphaticHeme { get; set; } = false;

        public bool Nervous { get; set; } = false;

        [Column(TypeName = "nvarchar(MAX)")] // Equivalente a text en SQL Server
        public string? Observations { get; set; }

        // Propiedad de navegación
        public virtual MedicalRecord? MedicalRecord { get; set; }
    }
}
