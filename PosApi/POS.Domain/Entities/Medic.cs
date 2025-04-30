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
    [Table("Medics")]
    [Index(nameof(UserId), IsUnique = true, Name = "uniqueMedicUser")]
    public class Medic : BaseEntity
    {
        [StringLength(20)] // Longitud típica para DNI
        public string? Dni { get; set; }

        [StringLength(20)] // Longitud típica para pasaporte
        public string? Passport { get; set; }

        [Required]
        [StringLength(25)]
        public string LastName { get; set; }

        [Required]
        [StringLength(25)]
        public string FirstName { get; set; }

        [StringLength(255)] // Longitud típica para nombres de archivo
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

        [StringLength(15)]
        public string? RegProfessional { get; set; }

        [ForeignKey("User")]
        public int? UserId { get; set; }

        // Propiedades de navegación
        public virtual User? User { get; set; }
        public virtual ICollection<MedicalRecord> MedicalRecords { get; set; } = new List<MedicalRecord>();
        public virtual ICollection<MedicalSpecialty> MedicalSpecialties { get; set; } = new List<MedicalSpecialty>();

        // Tabla intermedia para la relación muchos-a-muchos
        public virtual ICollection<Specialist> Specialists { get; set; } = new List<Specialist>();

        public Medic()
        {
            LastName = string.Empty;
            FirstName = string.Empty;
            Address = string.Empty;
        }
    }
}
