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
    [Table("Profiles")]
    [Index(nameof(Email), IsUnique = true, Name = "uniqueProfileEmail")]
    [Index(nameof(Dni), IsUnique = true, Name = "uniqueProfileDni")]
    [Index(nameof(Passport), IsUnique = true, Name = "uniqueProfilePassport")]
    public class ProfileSys : BaseEntity
    {
        [StringLength(20)] // Longitud adecuada para DNI
        public string? Dni { get; set; }

        [StringLength(20)] // Longitud adecuada para pasaporte
        public string? Passport { get; set; }

        [Required]
        [StringLength(25)]
        public string LastName { get; set; }

        [Required]
        [StringLength(25)]
        public string FirstName { get; set; }

        [Phone]
        [StringLength(20)]
        public string? Telephone { get; set; }

        [Phone]
        [StringLength(20)]
        public string? Mobile { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(255)] // Longitud para nombres de archivo
        public string? Image { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(MAX)")] // Para direcciones largas
        public string Address { get; set; }

        // Propiedad de navegación (relación uno-a-uno con User)
        public virtual User? User { get; set; }

        public ProfileSys()
        {
            // Inicialización de campos requeridos
            LastName = string.Empty;
            FirstName = string.Empty;
            Email = string.Empty;
            Address = string.Empty;
        }
    }
}
