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
    public class SpecialistConfiguration : IEntityTypeConfiguration<Specialist>
    {
        public void Configure(EntityTypeBuilder<Specialist> builder)
        {
            builder.ToTable("Specialists");

            builder.HasKey(keyExpression: e => e.Id);
            builder.Property(e => e.Id).HasColumnName("SpecialistId");

            builder.HasIndex(e => new { e.MedicId, e.MedicalSpecialtyId })
                .IsUnique()
                .HasDatabaseName("IX_Specialist_Medic_MedicalSpecialty");

            builder.HasOne(e => e.Medic)
               .WithMany(m => m.Specialists)
               .HasForeignKey(e => e.MedicId)
               .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.MedicalSpecialty)
               .WithMany(s => s.Specialists)
               .HasForeignKey(e => e.MedicalSpecialtyId)
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
