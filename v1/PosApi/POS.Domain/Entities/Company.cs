using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace POS.Domain.Entities
{
    public class Company : BaseEntity
    {
        public string Name { get; set; }
        public string? SmallName { get; set; }
        public string? Description { get; set; }
        public string? Logo { get; set; }
        public string? Telephone { get; set; }
        public string? Mobile { get; set; }
        public string? Email { get; set; }
        public string Address { get; set; }
        public string Manager { get; set; }
        public string? Ruc { get; set; }
        public string PrimaryColor { get; set; }
        public string SecondaryColor { get; set; }
        public Company()
        {
            Name = string.Empty;
            Address = string.Empty;
            Manager = string.Empty;
            PrimaryColor = string.Empty;
            SecondaryColor = string.Empty;
        }
    }
}
