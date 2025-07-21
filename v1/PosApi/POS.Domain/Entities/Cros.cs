using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Entities
{
    public class Cros : BaseEntity
    {
        public bool SenseOrgans { get; set; } = false;
        public bool Respiratory { get; set; } = false;
        public bool Cardiovascular { get; set; } = false;
        public bool Digestive { get; set; } = false;
        public bool Genital { get; set; } = false;
        public bool Urinary { get; set; } = false;
        public bool SkeletalMuscle { get; set; } = false;
        public bool Endocrine { get; set; } = false;
        public bool LymphaticHeme { get; set; } = false;
        public bool Nervous { get; set; } = false;
        public string? Observations { get; set; }
        public int MedicalRecordId { get; set; }
        public virtual MedicalRecord? MedicalRecord { get; set; }
    }
}
