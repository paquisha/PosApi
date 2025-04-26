using Microsoft.EntityFrameworkCore;
using POS.Domain.Entities;
using System.Reflection;

namespace POS.Infraestructure.Persistences.Contexts
{
    public partial class PosContext : DbContext
    {
        public PosContext()
        {
        }
        public PosContext(DbContextOptions<PosContext> options)
            : base(options: options)
        {
        }

        public virtual DbSet<Persona> Personas { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation(annotation: "Relational:Collation", value: "Moder_Spanish_CI_AS");
            modelBuilder.ApplyConfigurationsFromAssembly(assembly: Assembly.GetExecutingAssembly());
            OnModelCreatingPartial(modelBuilder: modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
