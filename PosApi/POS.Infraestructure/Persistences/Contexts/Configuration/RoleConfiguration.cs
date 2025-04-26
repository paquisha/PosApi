using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using POS.Domain.Entities;

namespace POS.Infraestructure.Persistences.Contexts.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(keyExpression: e => e.RoleId).HasName(name: "PK__Roles");

            builder.Property(propertyExpression: e => e.Description)
                .HasMaxLength(maxLength: 50)
                .IsUnicode(unicode: false);
        }
    }
}
