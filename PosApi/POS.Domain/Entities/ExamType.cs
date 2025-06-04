using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Entities
{
    public class ExamType : BaseEntity
    {
        public string Name { get; set; }
        // Relación uno-a-muchos con Exam
        public virtual ICollection<Exam> Exams { get; set; } = new List<Exam>();
        public ExamType()
        {
            Name = string.Empty;
        }
    }
}
