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
    public class DiagnosticConfiguration : IEntityTypeConfiguration<Diagnostic>
    {
        public void Configure(EntityTypeBuilder<Diagnostic> builder)
        {
            builder.ToTable("Diagnostics");
            builder.HasKey(keyExpression: e => e.Id);
            builder.Property(e => e.Id).HasColumnName("DiagnosticId");
            
            builder.HasIndex(e => new { e.MedicalRecordId, e.DiseaseId })
                .IsUnique()
                .HasDatabaseName("uniqueDiagnosticCombination");
            
            builder.HasOne(d => d.MedicalRecord)
                .WithMany(m => m.Diagnostics)
                .HasForeignKey(d => d.MedicalRecordId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
            
            builder.HasOne(d => d.Disease)
                .WithMany(m => m.Diagnostics)
                .HasForeignKey(d => d.DiseaseId)
                .IsRequired();
        }
    }
}
