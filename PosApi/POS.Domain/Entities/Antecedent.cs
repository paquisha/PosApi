using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Entities
{
    public class Antecedent : BaseEntity
    {
        [StringLength(200)]
        public string? Personal { get; set; }

        [StringLength(200)]
        public string? Surgical { get; set; }

        [StringLength(200)]
        public string? Family { get; set; }

        [StringLength(200)]
        public string? Professional { get; set; }

        [StringLength(200)]
        public string? Habits { get; set; }

        [StringLength(200)]
        public string? Clinician { get; set; }

        [StringLength(200)]
        public string? Trauma { get; set; }

        [StringLength(200)]
        public string? Allergy { get; set; }

        [StringLength(200)]
        public string? Ago { get; set; }

        [Required]
        [ForeignKey("Patient")]
        public int PatientId { get; set; }

        // Propiedad de navegación (opcional)
        public virtual Patient? Patient { get; set; }
    }
}
