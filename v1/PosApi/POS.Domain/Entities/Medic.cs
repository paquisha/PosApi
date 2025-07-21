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
    public class Medic : BaseEntity
    {
        public string? Dni { get; set; }
        public string? Passport { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string? Image { get; set; }
        public string? Telephone { get; set; }
        public string? Mobile { get; set; }
        public string? Email { get; set; }
        public string Address { get; set; }
        public string? RegProfessional { get; set; }
        public int? UserId { get; set; }
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
