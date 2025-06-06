﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POS.Domain.Entities;

namespace POS.Infraestructure.Persistences.Contexts.Configuration
{
    public class DiseaseTypeConfiguration : IEntityTypeConfiguration<DiseaseType>
    {
        public void Configure(EntityTypeBuilder<DiseaseType> builder)
        {
            builder.ToTable("DiseaseTypes");
            builder.HasKey(keyExpression: e => e.Id);
            builder.Property(e => e.Id)
                .HasColumnName("DiseaseTypeId");

            builder.Property(propertyExpression: e => e.Name).HasMaxLength(100);
            //builder.Property(propertyExpression: e => e.Image).IsUnicode(unicode: false);

            builder.HasMany(e => e.Diseases)
                .WithOne(d => d.DiseaseType)
                .HasForeignKey(d => d.DiseaseTypeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
