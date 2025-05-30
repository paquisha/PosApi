using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Entities
{
    public class MedicalSpecialty : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        // Propiedad de navegación para la relación con Medic
        public virtual ICollection<Medic> Medics { get; set; } = new List<Medic>();

        // Propiedad de navegación para la relación a través de Specialist
        public virtual ICollection<Specialist> Specialists { get; set; } = new List<Specialist>();

        public MedicalSpecialty()
        {
            Name = string.Empty;
            Description = string.Empty;
        }
    }
}
