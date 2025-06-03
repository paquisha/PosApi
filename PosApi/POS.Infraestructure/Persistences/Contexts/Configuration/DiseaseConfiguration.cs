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
    public class DiseaseConfiguration : IEntityTypeConfiguration<Disease>
    {
        public void Configure(EntityTypeBuilder<Disease> builder)
        {
            builder.ToTable("Diseases");
            builder.HasKey(keyExpression: e => e.Id);
            builder.Property(e => e.Id).HasColumnName("DiseaseId");

            builder.Property(propertyExpression: e => e.Code).HasMaxLength(10).IsUnicode(unicode: false);

            builder.Property(propertyExpression: e => e.Name)
                .IsRequired()
                .HasColumnType("varchar(MAX)");

            builder.Property(propertyExpression: e => e.Description).HasColumnType("varchar(MAX)");

            builder.Property(propertyExpression: e => e.Actions).HasColumnType("varchar(MAX)");

            builder.HasMany(d => d.Diagnostics)
                .WithOne()
                .HasForeignKey(di => di.DiseaseId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(d => d.MedicalRecords)
                .WithMany(mr => mr.Diseases)
                .UsingEntity<Dictionary<string, object>>(
                    "DiseaseMedicalRecords",
                    j => j.HasOne<MedicalRecord>().WithMany().HasForeignKey("MedicalRecordId"),
                    j => j.HasOne<Disease>().WithMany().HasForeignKey("DiseaseId"),
                    j => j.ToTable("DiseaseMedicalRecords"));
        }
    }
}
