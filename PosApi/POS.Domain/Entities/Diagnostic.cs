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
    [Table("Diagnostics")]
    [Index(nameof(MedicalRecordId), nameof(DiseaseId), IsUnique = true, Name = "uniqueDiagnosticCombination")]
    public class Diagnostic : BaseEntity
    {
        [Required]
        [ForeignKey("MedicalRecord")]
        public int MedicalRecordId { get; set; }

        [Required]
        [ForeignKey("Disease")]
        public int DiseaseId { get; set; }

        // Propiedades de navegación
        public virtual MedicalRecord? MedicalRecord { get; set; }

        public virtual Disease? Disease
        {
            get; set;
        }
    }
}
