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
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable("Companies");
            
            builder.HasKey(keyExpression: e => e.Id).HasName(name: "PK__Companies");
            builder.Property(e => e.Id).HasColumnName("CompanyId");
            
            builder.Property(e => e.Name).HasMaxLength(25).IsRequired();
            builder.Property(e => e.SmallName).HasMaxLength(25);
            builder.Property(e => e.Description).HasMaxLength(150);
            builder.Property(e => e.Logo).HasMaxLength(50);
            builder.Property(e => e.Telephone).HasMaxLength(8);
            builder.Property(e => e.Address).HasMaxLength(100);
            builder.Property(e => e.Mobile).HasMaxLength(10);
            builder.Property(e => e.Email).HasMaxLength(100);
            builder.Property(e => e.Address).HasMaxLength(100).IsRequired();
            builder.Property(e => e.Manager).HasMaxLength(50);

            builder.HasIndex(e => e.Ruc)
                .IsUnique()
                .HasDatabaseName("Ruc");
            
            builder.Property(e => e.Ruc)
                .IsUnicode(false)
                .HasMaxLength(13);

            builder.Property(e => e.PrimaryColor)
                .HasMaxLength(25)
                .IsRequired();
            
            builder.Property(e => e.SecondaryColor)
                .HasMaxLength(25)
                .IsRequired();
        }
    }
}
