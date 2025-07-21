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
    public class CrosConfiguration : IEntityTypeConfiguration<Cros>
    {
        public void Configure(EntityTypeBuilder<Cros> builder)
        {
            builder.ToTable("Cros");
            builder.HasKey(keyExpression: e => e.Id);
            builder.Property(e => e.Id).HasColumnName("CrosId");
            builder.Property(e => e.SenseOrgans).HasDefaultValue(false);
            builder.Property(e => e.Respiratory).HasDefaultValue(false);
            builder.Property(e => e.Cardiovascular).HasDefaultValue(false);
            builder.Property(e => e.Digestive).HasDefaultValue(false);
            builder.Property(e => e.Genital).HasDefaultValue(false);
            builder.Property(e => e.Urinary).HasDefaultValue(false);
            builder.Property(e => e.SkeletalMuscle).HasDefaultValue(false);
            builder.Property(e => e.Endocrine).HasDefaultValue(false);
            builder.Property(e => e.LymphaticHeme).HasDefaultValue(false);
            builder.Property(e => e.Nervous).HasDefaultValue(false);
            builder.Property(e => e.Observations).HasColumnType("varchar(MAX)");
            builder
                .HasOne(c => c.MedicalRecord)
                .WithOne(m => m.Cros)
                .HasForeignKey<Cros>(fk => fk.MedicalRecordId)
                .OnDelete(deleteBehavior: DeleteBehavior.Cascade);
        }
    }
}
