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
    public class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.ToTable("tgroup");
            builder.HasKey(keyExpression: e => e.Id);
            builder.Property(e => e.Id).HasColumnName("GroupId");
            builder.Property(propertyExpression: e => e.Name).IsRequired().HasMaxLength(30);
            // Relación uno a muchos con Option
            builder.HasMany(g => g.Options)
                .WithOne(o => o.Group)
                .HasForeignKey(o => o.GroupId)
                .OnDelete(DeleteBehavior.Restrict); 
        }
    }
}
