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
    [Table("Modules")]
    [Index(nameof(Name), IsUnique = true, Name = "uniqueModuleName")]
    public class ModuleMed : BaseEntity
    {
        [Required]
        [StringLength(25)]
        public string Name { get; set; }
        [InverseProperty("Module")]
        public virtual ICollection<Permission> Permissions { get; set; } = new List<Permission>();

        // Relación muchos-a-muchos con Role a través de Permission
        [InverseProperty("Module")]
        public virtual ICollection<Role> Roles { get; set; } = new List<Role>();
        public ModuleMed()
        {
            Name = string.Empty;
        }
    }
}
