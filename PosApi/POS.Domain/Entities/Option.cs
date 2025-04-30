using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace POS.Domain.Entities
{
    [Table("Options")]
    [Index(nameof(Name), nameof(GroupId), IsUnique = true, Name = "uniqueOptionCombination")]
    public class Option : BaseEntity
    {
        [Required]
        [StringLength(75)]
        public string Name { get; set; }

        [Required]
        [ForeignKey("Group")]
        public int GroupId { get; set; }

        public virtual Group? Group { get; set; }

        public Option()
        {
            Name = string.Empty;
        }
    }
}
