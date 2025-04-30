using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Entities
{
    [Table("VitalSigns")]
    public class VitalSign : BaseEntity
    {
        [Required]
        [StringLength(6)]
        public string Temperature { get; set; }

        [Required]
        [StringLength(6)]
        public string SystolicPressure { get; set; }

        [Required]
        [StringLength(6)]
        public string DiastolicPressure { get; set; }

        [Required]
        [StringLength(6)]
        public string Pulse { get; set; }

        [Required]
        [StringLength(6)]
        public string BreathingFrequency { get; set; }

        [Required]
        [StringLength(6)]
        public string OxygenSaturation { get; set; }

        [Required]
        [StringLength(6)]
        public string Tall { get; set; }

        [Required]
        [StringLength(6)]
        public string Weight { get; set; }

        [Required]
        [StringLength(6)]
        public string Mass { get; set; }

        [Required]
        [ForeignKey("MedicalRecord")]
        public int MedicalRecordId { get; set; }

        // Propiedad de navegación
        public virtual MedicalRecord? MedicalRecord { get; set; }

        public VitalSign()
        {
            // Inicialización de campos requeridos
            Temperature = string.Empty;
            SystolicPressure = string.Empty;
            DiastolicPressure = string.Empty;
            Pulse = string.Empty;
            BreathingFrequency = string.Empty;
            OxygenSaturation = string.Empty;
            Tall = string.Empty;
            Weight = string.Empty;
            Mass = string.Empty;
        }
    }
}
