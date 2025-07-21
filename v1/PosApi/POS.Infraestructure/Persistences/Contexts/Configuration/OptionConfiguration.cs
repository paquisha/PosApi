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
    public class OptionConfiguration : IEntityTypeConfiguration<Option>
    {
        public void Configure(EntityTypeBuilder<Option> builder)
        {
            builder.ToTable("Options");
            builder.HasKey(keyExpression: e => e.Id);
            builder.Property(e => e.Id).HasColumnName("OptionId");
            builder.Property(propertyExpression: e => e.Name).IsRequired().HasMaxLength(75);
            builder.Property(e => e.GroupId)
                .IsRequired();
            // Índice único compuesto
            builder.HasIndex(o => new { o.Name, o.GroupId })
                .IsUnique()
                .HasDatabaseName("uniqueOptionCombination");
        }
    }
}
