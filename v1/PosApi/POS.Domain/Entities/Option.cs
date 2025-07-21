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
    [Index(nameof(Name), nameof(GroupId), IsUnique = true, Name = "uniqueOptionCombination")]
    public class Option : BaseEntity
    {
        public string Name { get; set; }
        public int GroupId { get; set; }
        public virtual Group? Group { get; set; }
        public Option()
        {
            Name = string.Empty;
        }
    }
}
