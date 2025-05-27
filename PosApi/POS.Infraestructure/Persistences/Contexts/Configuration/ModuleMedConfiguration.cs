using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POS.Domain.Entities;

namespace POS.Infraestructure.Persistences.Contexts.Configuration
{
    public class ModuleMedConfiguration : IEntityTypeConfiguration<ModuleMed>
    {
        public void Configure(EntityTypeBuilder<ModuleMed> builder)
        {
            builder.HasKey(keyExpression: e => e.Id);
            builder.Property(e => e.Id).HasColumnName("ModuleMedId");

            builder.Property(propertyExpression: e => e.Name).IsUnicode(unicode: false);
            //builder.Property(propertyExpression: e => e.Image).IsUnicode(unicode: false);
        }
    }
}
