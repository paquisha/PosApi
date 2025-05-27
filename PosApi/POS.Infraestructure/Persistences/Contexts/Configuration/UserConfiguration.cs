using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POS.Domain.Entities;

namespace POS.Infraestructure.Persistences.Contexts.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(keyExpression: e => e.Id);
            builder.Property(e => e.Id)
                .HasColumnName("UserId");

            builder.Property(propertyExpression: e => e.Email).IsUnicode(unicode: false);
            //builder.Property(propertyExpression: e => e.Image).IsUnicode(unicode: false);
            builder.Property(propertyExpression: e => e.Password).IsUnicode(unicode: false);
            //builder.Property(propertyExpression: e => e.UserName)
            //    .HasMaxLength(maxLength: 50)
            //    .IsUnicode(unicode: false);
        }
    }
}