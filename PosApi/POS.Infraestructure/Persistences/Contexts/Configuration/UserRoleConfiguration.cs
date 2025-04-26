using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using POS.Domain.Entities;

namespace POS.Infraestructure.Persistences.Contexts.Configuration
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasKey(keyExpression: e => e.UserRoleId).HasName(name: "PK__UserRole");

            builder.HasOne(navigationExpression: d => d.Role).WithMany(navigationExpression: p => p.UserRoles)
                .HasForeignKey(foreignKeyExpression: d => d.RoleId)
                .HasConstraintName(name: "FK__UserRoles__RoleId");

            builder.HasOne(navigationExpression: d => d.User).WithMany(navigationExpression: p => p.UserRoles)
                .HasForeignKey(foreignKeyExpression: d => d.UserId)
                .HasConstraintName(name: "FK__UserRoles__UserId");
        }
    }
}
