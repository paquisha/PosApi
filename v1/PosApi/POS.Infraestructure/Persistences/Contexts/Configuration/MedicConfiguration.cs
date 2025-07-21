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
    public class MedicConfiguration : IEntityTypeConfiguration<Medic>
    {
        public void Configure(EntityTypeBuilder<Medic> builder)
        {
            builder.ToTable("Medics");

            builder.HasKey(keyExpression: e => e.Id);
            builder.Property(e => e.Id).HasColumnName("MedicId");

            builder.HasIndex(e => e.UserId)
                .IsUnique()
                .HasDatabaseName("uniqueMedicUser");

            builder.Property(e => e.Dni).HasMaxLength(20).IsUnicode(unicode: false);

            builder.Property(e => e.Passport).HasMaxLength(20).IsUnicode(unicode: false);

            builder.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(25)
                .IsUnicode(unicode: false);

            builder.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(25)
                .IsUnicode(unicode: false);

            builder.Property(e => e.Image).HasMaxLength(255).IsUnicode(false);

            builder.Property(e => e.Telephone).HasMaxLength(20).IsUnicode(false);

            builder.Property(e => e.Mobile).HasMaxLength(20).IsUnicode(false);

            builder.Property(e => e.Email).HasMaxLength(100).IsUnicode(false);

            builder.Property(e => e.Address).IsRequired()
                .HasColumnType("nvarchar(MAX)")
                .IsUnicode(unicode: false);

            builder.Property(e => e.RegProfessional).HasMaxLength(15).IsUnicode(false);

            builder.HasOne(e => e.User)
                .WithMany()
                .HasForeignKey(e => e.UserId);
        }
    }
}
