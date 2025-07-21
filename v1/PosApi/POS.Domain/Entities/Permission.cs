using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace POS.Domain.Entities
{
    [Table("Permissions")]
    [Index(nameof(RoleId), nameof(ModuleId), IsUnique = true, Name = "uniquePermissionCombination")]
    public class Permission : BaseEntity
    {
        [Required]
        [Column("c")] // Mapeo a nombre de columna corto
        public bool Create { get; set; } = false;

        [Required]
        [Column("r")]
        public bool Read { get; set; } = true;

        [Required]
        [Column("u")] // 'u' para update (editar)
        public bool Edit { get; set; } = false;

        [Required]
        [Column("d")] // 'd' para delete
        public bool Delete { get; set; } = false; // Cambiado de 'del' a 'Delete' por convención

        [Required]
        [ForeignKey("Role")]
        public int RoleId { get; set; }

        [Required]
        [ForeignKey("Module")]
        public int ModuleId { get; set; }

        // Propiedades de navegación
        public virtual Role? Role { get; set; }
        public virtual ModuleMed? Module { get; set; }

        public Permission()
        {
            // Valores por defecto ya asignados en las propiedades
        }
    }
}
