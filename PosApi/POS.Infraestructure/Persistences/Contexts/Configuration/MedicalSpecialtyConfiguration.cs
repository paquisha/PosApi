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
    public class MedicalSpecialtyConfiguration : IEntityTypeConfiguration<MedicalSpecialty>
    {
        public void Configure(EntityTypeBuilder<MedicalSpecialty> builder)
        {
            builder.ToTable("MedicalSpecialties");

            builder.HasKey(keyExpression: e => e.Id);
            builder.Property(e => e.Id).HasColumnName("MedicalRecordId");

            builder.Property(propertyExpression: e => e.Name)
                .IsRequired()
                .HasMaxLength(75)
                .IsUnicode(unicode: false);

            builder.Property(propertyExpression: e => e.Description)
                .HasMaxLength(150)
                .IsUnicode(unicode: false);
            //builder.Property(propertyExpression: e => e.Image).IsUnicode(unicode: false);
        }
    }
}
