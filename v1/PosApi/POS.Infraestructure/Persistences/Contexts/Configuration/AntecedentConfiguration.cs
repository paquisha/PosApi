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
    public class AntecedentConfiguration : IEntityTypeConfiguration<Antecedent>
    {
        public void Configure(EntityTypeBuilder<Antecedent> builder)
        {
            builder.ToTable("Antecedent");
            
            builder.HasKey(keyExpression: e => e.Id).HasName(name: "PK__Antecedent");
            builder.Property(e => e.Id).HasColumnName("AntecedentId");

            builder.Property(e => e.Personal).HasMaxLength(200);
            builder.Property(e => e.Surgical).HasMaxLength(200);
            builder.Property(e => e.Family).HasMaxLength(200);
            builder.Property(e => e.Professional).HasMaxLength(200);
            builder.Property(e => e.Habits).HasMaxLength(200);
            builder.Property(e => e.Clinician).HasMaxLength(200);
            builder.Property(e => e.Trauma).HasMaxLength(200);
            builder.Property(e => e.Allergy).HasMaxLength(200);
            builder.Property(e => e.Ago).HasMaxLength(200);
            
            builder
                .HasOne(a => a.Patient)
                .WithOne(p => p.Antecedent)
                .HasForeignKey<Antecedent>(fk => fk.PatientId)
                .OnDelete(deleteBehavior: DeleteBehavior.Cascade);
        }
    }
}
