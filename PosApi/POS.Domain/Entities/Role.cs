using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace POS.Domain.Entities
{
    [Table("Roles")]
    [Index(nameof(Name), IsUnique = true, Name = "uniqueRoleName")]
    public class Role : BaseEntity
    {
        [Required]
        [StringLength(25)]
        public string Name { get; set; }
        [Required]
        [StringLength(150)]
        public string? Description { get; set; }
        public int? Status { get; set; }
        // Relación muchos-a-muchos con Module a través de Permission
        public virtual ICollection<ModuleMed> Modules { get; set; } = new List<ModuleMed>();

        // Colección de permisos (tabla intermedia)
        public virtual ICollection<Permission> Permissions { get; set; } = new List<Permission>();

        public Role()
        {
            Name = string.Empty;
            Description = string.Empty;
        }
    }
}
