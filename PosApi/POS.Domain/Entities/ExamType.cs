using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Entities
{
    [Table("ExamTypes")]
    public class ExamType : BaseEntity
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        // Relación uno-a-muchos con Exam
        public virtual ICollection<Exam> Exams { get; set; } = new List<Exam>();

        public ExamType()
        {
            Name = string.Empty; // Inicialización del campo requerido
        }
    }
}
