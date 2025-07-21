using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Entities
{
    [Table("Rpes")]
    public class Rpe : BaseEntity
    {
        public bool Head { get; set; } = false;

        public bool Neck { get; set; } = false;

        public bool Chest { get; set; } = false;

        public bool Abdomen { get; set; } = false;

        public bool Pelvis { get; set; } = false;

        public bool Extremities { get; set; } = false;

        [Column(TypeName = "nvarchar(MAX)")]
        public string? Observations { get; set; }

        [Required]
        [ForeignKey("MedicalRecord")]
        public int MedicalRecordId { get; set; }

        // Propiedad de navegación
        public virtual MedicalRecord? MedicalRecord { get; set; }

        public Rpe()
        {
            // Constructor para inicialización si es necesaria
        }
    }
}
