using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Entities
{
    public class Group : BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<Option> Options { get; set; }
        public Group()
        {
            Name = string.Empty;
            Options = new HashSet<Option>();
        }
    }
}
