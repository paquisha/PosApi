using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace POS.Domain.Entities
{
    [Table("Companies")] // Opcional: si quieres cambiar el nombre de la tabla
    [Index(nameof(Ruc), IsUnique = true, Name = "uniqueCompanyRuc")]
    public class Company : BaseEntity
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(25)]
        public string? SmallName { get; set; }

        [StringLength(150)]
        public string? Description { get; set; }

        [StringLength(50)]
        public string? Logo { get; set; }

        [Phone] // Valida formato de teléfono
        [StringLength(20)] // Longitud sugerida para teléfono
        public string? Telephone { get; set; }

        [Phone]
        [StringLength(20)]
        public string? Mobile { get; set; }

        [EmailAddress] // Valida formato de email
        [StringLength(100)] // Longitud sugerida para email
        public string? Email { get; set; }

        [Required]
        [StringLength(100)]
        public string Address { get; set; }

        [StringLength(50)]
        public string Manager { get; set; }

        [StringLength(10)]
        public string? Ruc { get; set; }

        [Required]
        [StringLength(25)]
        public string PrimaryColor { get; set; }

        [Required]
        [StringLength(25)]
        public string SecondaryColor { get; set; }

        public Company()
        {
            Name = string.Empty;
            Address = string.Empty;
            Manager = string.Empty;
            PrimaryColor = string.Empty;
            SecondaryColor = string.Empty;
        }
    }
}
