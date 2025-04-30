using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace POS.Domain.Entities
{
    [Table("Patients")]
    [Index(nameof(Dni), IsUnique = true, Name = "uniquePatientDNI")]
    [Index(nameof(Passport), IsUnique = true, Name = "uniquePatientPassport")]
    [Index(nameof(Hc), IsUnique = true, Name = "uniquePatientHC")]
    public class Patient : BaseEntity
    {
        [StringLength(20)] // Longitud adecuada para DNI
        public string? Dni { get; set; }

        [StringLength(20)] // Longitud adecuada para pasaporte
        public string? Passport { get; set; }

        [Required]
        [StringLength(10)]
        public string Hc { get; set; }

        [Required]
        [StringLength(25)]
        public string LastName { get; set; }

        [Required]
        [StringLength(25)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100)]
        public string Occupation { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime Birthday { get; set; }

        [StringLength(255)] // Longitud para nombres de archivo
        public string? Image { get; set; }

        [Phone]
        [StringLength(20)]
        public string? Telephone { get; set; }

        [Phone]
        [StringLength(20)]
        public string? Mobile { get; set; }

        [EmailAddress]
        [StringLength(100)]
        public string? Email { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(MAX)")] // Para direcciones largas
        public string Address { get; set; }

        public int? BloodType { get; set; } // Corregido de 'blooType' a 'BloodType'

        [Required]
        public int Sex { get; set; }

        [Required]
        public int CivilStatus { get; set; }

        // Propiedades de navegación
        public virtual Antecedent? Antecedent { get; set; }
        public virtual ICollection<MedicalRecord> MedicalRecords { get; set; } = new List<MedicalRecord>();

        public Patient()
        {
            // Inicialización de campos requeridos
            Hc = string.Empty;
            LastName = string.Empty;
            FirstName = string.Empty;
            Occupation = string.Empty;
            Address = string.Empty;
        }
    }
}
