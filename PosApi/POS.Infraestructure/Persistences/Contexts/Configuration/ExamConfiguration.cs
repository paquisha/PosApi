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
    public class ExamConfiguration : IEntityTypeConfiguration<Exam>
    {
        public void Configure(EntityTypeBuilder<Exam> builder)
        {
            builder.ToTable("Exams");
            builder.HasKey(keyExpression: e => e.Id);
            builder.Property(e => e.Id).HasColumnName("ExamId");
            builder.Property(propertyExpression: e => e.Name)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(e => e.ExamTypeId)
                .IsRequired();
            // Configuración de la relación con ExamType
            builder.HasOne(e => e.ExamType)
                .WithMany(et => et.Exams)
                .HasForeignKey(e => e.ExamTypeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
