using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POS.Domain.Entities;

namespace POS.Infraestructure.Persistences.Contexts.Configuration
{
    public class PersonaConfiguration : IEntityTypeConfiguration<Persona>
    {
        public void Configure(EntityTypeBuilder<Persona> builder)
        {
            builder.HasKey(keyExpression: e => e.Id);
            builder.Property(e => e.Id).HasColumnName("PersonId");

            builder.Property(propertyExpression: e => e.FirtsName).IsUnicode(unicode: false);
            builder.Property(propertyExpression: e => e.LastName).IsUnicode(unicode: false);
            builder.Property(propertyExpression: e => e.Email).IsUnicode(unicode: false);
        }
    }
}
