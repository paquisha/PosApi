using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Entities
{
    public class Specialist : BaseEntity
    {
        public int MedicId { get; set; }
        public int MedicalSpecialtyId { get; set; }

        public virtual Medic? Medic { get; set; }
        public virtual MedicalSpecialty? MedicalSpecialty { get; set; }

        public Specialist()
        {
        }
    }
}
