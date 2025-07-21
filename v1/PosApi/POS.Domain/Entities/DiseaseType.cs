using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Entities
{
    public class DiseaseType : BaseEntity
    {
        public string Name { get; set; }

        // Relación uno-a-muchos con Disease
        public virtual ICollection<Disease> Diseases { get; set; } = new List<Disease>();

        public DiseaseType()
        {
            Name = string.Empty; // Inicialización del campo requerido
        }
    }
}
