using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Entities
{
    [Table("Diseases")]
    public class Disease : BaseEntity
    {
        [StringLength(10)]
        public string? Code { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(MAX)")]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        public string? Description { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        public string? Actions { get; set; }

        [Required]
        [ForeignKey("DiseaseType")]
        public int DiseaseTypeId { get; set; }
        public virtual DiseaseType? DiseaseType { get; set; }
        [InverseProperty("Disease")]
        public virtual ICollection<Diagnostic> Diagnostics { get; set; } = new List<Diagnostic>();

        [InverseProperty("Diseases")]
        public virtual ICollection<MedicalRecord> MedicalRecords { get; set; } = new List<MedicalRecord>();

        public Disease()
        {
            Name = string.Empty;
        }
    }
}
