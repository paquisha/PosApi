using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Entities
{
    public class Antecedent : BaseEntity
    {
        public string? Personal { get; set; }
        public string? Surgical { get; set; }
        public string? Family { get; set; }
        public string? Professional { get; set; }
        public string? Habits { get; set; }
        public string? Clinician { get; set; }
        public string? Trauma { get; set; }
        public string? Allergy { get; set; }
        public string? Ago { get; set; }
        public int PatientId { get; set; }
        public virtual Patient? Patient { get; set; }
    }
}
