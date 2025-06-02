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
    public class Diagnostic : BaseEntity
    {
        public int MedicalRecordId { get; set; }
        public virtual MedicalRecord? MedicalRecord { get; set; }
        public int DiseaseId { get; set; }
        public virtual Disease? Disease { get; set; }
    }
}
