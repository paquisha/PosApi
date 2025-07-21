using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Entities
{
    public class Disease : BaseEntity
    {
        public string? Code { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Actions { get; set; }
        public int DiseaseTypeId { get; set; }
        public virtual DiseaseType? DiseaseType { get; set; }
        public virtual ICollection<Diagnostic> Diagnostics { get; set; } = new List<Diagnostic>();
        public virtual ICollection<MedicalRecord> MedicalRecords { get; set; } = new List<MedicalRecord>();
    }
}
