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
        public virtual DbSet<Antecedent> Antecedents { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Cros> Cros { get; set; }
        public virtual DbSet<Diagnostic> Diagnostics { get; set; }
        public virtual DbSet<Disease> Diseases { get; set; }
        public virtual DbSet<DiseaseType> GetDiseaseTypes { get; set; }
        public virtual DbSet<Exam> Exams { get; set; }
        public virtual DbSet<ExamType> ExamsType { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<Medic> Medics { get; set; }
        public virtual DbSet<MedicalExam> ExamsMedics { get; set; }
        public virtual DbSet<MedicalRecord> MedicalRecords { get; set; }
        public virtual DbSet<MedicalSpecialty> MedicalSpecialties { get; set; }
        public virtual DbSet<ModuleMed> Modules { get; set; }
        public virtual DbSet<Option> Options { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<ProfileSys> Profiles { get; set; }
        public virtual DbSet<Rpe> Rpes { get; set; }
        public virtual DbSet<Specialist> Specialists { get; set; }
        public virtual DbSet<VitalSign> VitalSigns { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation(annotation: "Relational:Collation", value: "Moder_Spanish_CI_AS");
            modelBuilder.ApplyConfigurationsFromAssembly(assembly: Assembly.GetExecutingAssembly());
            OnModelCreatingPartial(modelBuilder: modelBuilder);

            //Cros
            modelBuilder.Entity<Cros>(entity =>
            {
                // Configuración de la clave foránea
                entity.HasOne(c => c.MedicalRecord)
                      .WithMany() // Ajusta según tu modelo de datos
                      .HasForeignKey(c => c.MedicalRecordId)
                      .OnDelete(DeleteBehavior.Restrict) // O el comportamiento que prefieras
                      .HasConstraintName("fk_cros_medrec");
            });

            //Diagnostico
            modelBuilder.Entity<Diagnostic>(entity =>
            {
                // Configuración de la primera clave foránea
                entity.HasOne(d => d.MedicalRecord)
                      .WithMany() // Ajusta según tu modelo de datos
                      .HasForeignKey(d => d.MedicalRecordId)
                      .OnDelete(DeleteBehavior.Restrict) // O el comportamiento que prefieras
                      .HasConstraintName("fk_diagnostic_medrec");

                // Configuración de la segunda clave foránea
                entity.HasOne(d => d.Disease)
                      .WithMany() // Ajusta según tu modelo de datos
                      .HasForeignKey(d => d.DiseaseId)
                      .OnDelete(DeleteBehavior.Restrict) // O el comportamiento que prefieras
                      .HasConstraintName("fk_diagnostic_disease");
            });

            //DiseaseType
            modelBuilder.Entity<DiseaseType>(entity =>
            {
                // Configuración de la relación uno-a-muchos
                entity.HasMany(dt => dt.Diseases)
                      .WithOne(d => d.DiseaseType) // Asume que Disease tiene propiedad de navegación
                      .HasForeignKey(d => d.DiseaseTypeId) // Asume que Disease tiene FK
                      .OnDelete(DeleteBehavior.Cascade); // O el comportamiento que prefieras
            });

            modelBuilder.Entity<Disease>(entity =>
            {
                // Configure the foreign key relationship
                entity.HasOne(d => d.DiseaseType)
                      .WithMany(dt => dt.Diseases)
                      .HasForeignKey(d => d.DiseaseTypeId)
                      .OnDelete(DeleteBehavior.Restrict) // Or your preferred delete behavior
                      .HasConstraintName("fk_disease_diseasetype");
            });

            modelBuilder.Entity<ExamType>(entity =>
            {
                // Configuración de la relación uno-a-muchos
                entity.HasMany(et => et.Exams)
                      .WithOne(e => e.ExamType) // Asume que Exam tiene propiedad de navegación
                      .HasForeignKey(e => e.ExamTypeId) // Asume que Exam tiene FK
                      .OnDelete(DeleteBehavior.Cascade); // O el comportamiento que prefieras
            });

            modelBuilder.Entity<Exam>(entity =>
            {
                // Configuración de la clave foránea
                entity.HasOne(e => e.ExamType)
                      .WithMany(et => et.Exams)
                      .HasForeignKey(e => e.ExamTypeId)
                      .OnDelete(DeleteBehavior.Restrict) // O el comportamiento que prefieras
                      .HasConstraintName("fk_exam_examtype");
            });

            modelBuilder.Entity<Medic>(entity =>
            {
                // Configuración de la clave foránea
                entity.HasOne(m => m.User)
                      .WithMany()
                      .HasForeignKey(m => m.UserId)
                      .OnDelete(DeleteBehavior.Restrict)
                      .HasConstraintName("fk_medic_user");

                // Configuración de la relación uno-a-muchos con MedicalRecord
                entity.HasMany(m => m.MedicalRecords)
                      .WithOne(mr => mr.Medic)
                      .HasForeignKey(mr => mr.MedicId);

                // Configuración de la relación muchos-a-muchos con MedicalSpecialty
                entity.HasMany(m => m.MedicalSpecialties)
                      .WithMany(ms => ms.Medics)
                      .UsingEntity<Specialist>(
                          j => j.HasOne(s => s.MedicalSpecialty)
                                .WithMany()
                                .HasForeignKey(s => s.MedicalSpecialtyId),
                          j => j.HasOne(s => s.Medic)
                                .WithMany()
                                .HasForeignKey(s => s.MedicId),
                          j => j.ToTable("Specialists"));
            });

            modelBuilder.Entity<MedicalExam>(entity =>
            {
                // Configuración de la primera clave foránea
                entity.HasOne(me => me.MedicalRecord)
                      .WithMany(mr => mr.MedicalExams)
                      .HasForeignKey(me => me.MedicalRecordId)
                      .OnDelete(DeleteBehavior.Restrict)
                      .HasConstraintName("fk_medexam_medrec");

                // Configuración de la segunda clave foránea
                entity.HasOne(me => me.Exam)
                      .WithMany()
                      .HasForeignKey(me => me.ExamId)
                      .OnDelete(DeleteBehavior.Restrict)
                      .HasConstraintName("fk_medexam_exam");
            });

            modelBuilder.Entity<MedicalRecord>(entity =>
            {
                // Relación con Medic
                entity.HasOne(mr => mr.Medic)
                      .WithMany()
                      .HasForeignKey(mr => mr.MedicId)
                      .OnDelete(DeleteBehavior.Restrict)
                      .HasConstraintName("fk_medrec_medic");

                // Relación con Patient
                entity.HasOne(mr => mr.Patient)
                      .WithMany()
                      .HasForeignKey(mr => mr.PatientId)
                      .OnDelete(DeleteBehavior.Restrict)
                      .HasConstraintName("fk_medrec_patient");

                // Relación uno-a-uno con Rpe
                entity.HasOne(mr => mr.Rpe)
                      .WithOne()
                      .HasForeignKey<Rpe>(r => r.MedicalRecordId)
                      .OnDelete(DeleteBehavior.Cascade);

                // Relación uno-a-uno con Cros
                entity.HasOne(mr => mr.Cros)
                      .WithOne()
                      .HasForeignKey<Cros>(c => c.MedicalRecordId)
                      .OnDelete(DeleteBehavior.Cascade);

                // Relación uno-a-uno con VitalSign
                entity.HasOne(mr => mr.VitalSign)
                      .WithOne()
                      .HasForeignKey<VitalSign>(v => v.MedicalRecordId)
                      .OnDelete(DeleteBehavior.Cascade);

                // Relación muchos-a-muchos: MedicalRecord <-> Exam (tabla intermedia: MedicalExam)
                entity.HasMany(mr => mr.Exams)
                      .WithMany(e => e.MedicalRecords)
                      .UsingEntity<MedicalExam>(
                          j => j.HasOne(me => me.Exam)
                                .WithMany()
                                .HasForeignKey(me => me.ExamId),
                          j => j.HasOne(me => me.MedicalRecord)
                                .WithMany()
                                .HasForeignKey(me => me.MedicalRecordId),
                          j =>
                          {
                              j.ToTable("MedicalExams");
                              j.HasKey(me => me.Id); // Si tienes Id en MedicalExam
                          }
                      );

                // Relación muchos-a-muchos: MedicalRecord <-> Disease (tabla intermedia: Diagnostic)
                entity.HasMany(mr => mr.Diseases)
                      .WithMany(d => d.MedicalRecords)
                      .UsingEntity<Diagnostic>(
                          j => j.HasOne(di => di.Disease)
                                .WithMany()
                                .HasForeignKey(di => di.DiseaseId),
                          j => j.HasOne(di => di.MedicalRecord)
                                .WithMany()
                                .HasForeignKey(di => di.MedicalRecordId),
                          j =>
                          {
                              j.ToTable("Diagnostics");
                              j.HasKey(di => di.Id); // Si tienes Id en Diagnostic
                          }
                      );
            });


            modelBuilder.Entity<MedicalSpecialty>(entity =>
            {
                entity.HasIndex(ms => ms.Name)
                      .IsUnique()
                      .HasDatabaseName("idx_medicalspecialty_name_unique");
            });

            modelBuilder.Entity<Option>(entity =>
            {
                entity.HasOne(o => o.Group)
                      .WithMany(g => g.Options)
                      .HasForeignKey(o => o.GroupId)
                      .OnDelete(DeleteBehavior.Restrict)
                      .HasConstraintName("fk_option_group");
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                // Configuración de la relación uno-a-uno con Antecedent
                entity.HasOne(p => p.Antecedent)
                      .WithOne()
                      .HasForeignKey<Antecedent>(a => a.PatientId);

                // Configuración de la relación uno-a-muchos con MedicalRecord
                entity.HasMany(p => p.MedicalRecords)
                      .WithOne(mr => mr.Patient)
                      .HasForeignKey(mr => mr.PatientId);
            });

            modelBuilder.Entity<Permission>(entity =>
            {
                // Configuración de la primera clave foránea
                entity.HasOne(p => p.Role)
                      .WithMany()
                      .HasForeignKey(p => p.RoleId)
                      .OnDelete(DeleteBehavior.Restrict)
                      .HasConstraintName("fk_permission_role");

                // Configuración de la segunda clave foránea
                entity.HasOne(p => p.Module)
                      .WithMany()
                      .HasForeignKey(p => p.ModuleId)
                      .OnDelete(DeleteBehavior.Restrict)
                      .HasConstraintName("fk_permission_module");
            });

            modelBuilder.Entity<ProfileSys>(entity =>
            {
                // Configuración de la relación uno-a-uno con User
                entity.HasOne(p => p.User)
                      .WithOne(u => u.Profile)
                      .HasForeignKey<User>(u => u.ProfileId); // Asume que User tiene ProfileId
            });

            modelBuilder.Entity<Role>(entity =>
            {
                // Configuración de la relación muchos-a-muchos con Module
                entity.HasMany(r => r.Modules)
                      .WithMany(m => m.Roles)
                      .UsingEntity<Permission>(
                          j => j.HasOne(p => p.Module)
                                .WithMany()
                                .HasForeignKey(p => p.ModuleId),
                          j => j.HasOne(p => p.Role)
                                .WithMany()
                                .HasForeignKey(p => p.RoleId),
                          j => j.ToTable("Permissions"));
            });

            modelBuilder.Entity<Rpe>(entity =>
            {
                // Configuración de la clave foránea
                entity.HasOne(r => r.MedicalRecord)
                      .WithMany()
                      .HasForeignKey(r => r.MedicalRecordId)
                      .OnDelete(DeleteBehavior.Restrict) // O el comportamiento que prefieras
                      .HasConstraintName("fk_rpe_medrec");
            });

            modelBuilder.Entity<Specialist>(entity =>
            {
                // Configuración de la primera clave foránea
                entity.HasOne(s => s.Medic)
                      .WithMany(m => m.Specialists)
                      .HasForeignKey(s => s.MedicId)
                      .OnDelete(DeleteBehavior.Restrict)
                      .HasConstraintName("fk_specialist_medic");

                // Configuración de la segunda clave foránea
                entity.HasOne(s => s.MedicalSpecialty)
                      .WithMany(ms => ms.Specialists)
                      .HasForeignKey(s => s.MedicalSpecialtyId)
                      .OnDelete(DeleteBehavior.Restrict)
                      .HasConstraintName("fk_specialist_medspe");
            });

            modelBuilder.Entity<User>(entity =>
            {
                // Configuración de la clave foránea con Role
                entity.HasOne(u => u.Role)
                      .WithMany()
                      .HasForeignKey(u => u.RoleId)
                      .OnDelete(DeleteBehavior.Restrict)
                      .HasConstraintName("fk_user_role");

                // Configuración de la clave foránea con Profile
                entity.HasOne(u => u.Profile)
                      .WithOne()
                      .HasForeignKey<User>(u => u.ProfileId)
                      .OnDelete(DeleteBehavior.Restrict)
                      .HasConstraintName("fk_user_profile");

                // Configuración de la relación uno-a-uno con Medic
                entity.HasOne(u => u.Medic)
                      .WithOne(m => m.User)
                      .HasForeignKey<Medic>(m => m.UserId);
            });

            modelBuilder.Entity<VitalSign>(entity =>
            {
                // Configuración de la clave foránea
                entity.HasOne(vs => vs.MedicalRecord)
                      .WithMany()
                      .HasForeignKey(vs => vs.MedicalRecordId)
                      .OnDelete(DeleteBehavior.Restrict)
                      .HasConstraintName("fk_sign_medrec");
            });
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
