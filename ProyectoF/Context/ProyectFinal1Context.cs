using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ProyectoF.Models
{
    public partial class ProyectFinal1Context : DbContext
    {
        public ProyectFinal1Context()
        {
        }

        public ProyectFinal1Context(DbContextOptions<ProyectFinal1Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Estudiante> Estudiantes { get; set; }
        public virtual DbSet<Login> Logins { get; set; }
        public virtual DbSet<Materia> Materias { get; set; }
        public virtual DbSet<MateriasEstudiante> MateriasEstudiantes { get; set; }
        public virtual DbSet<MateriasProfesore> MateriasProfesores { get; set; }
        public virtual DbSet<Profesor> Profesors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-3R0RU12; Database=ProyectFinal1; Trusted_Connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Estudiante>(entity =>
            {
                entity.HasKey(e => e.IdEstudiante);

                entity.Property(e => e.IdEstudiante).HasColumnName("ID_Estudiante");

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Genero)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasMaxLength(12)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.ToTable("login");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Materia>(entity =>
            {
                entity.HasKey(e => e.IdMateria);

                entity.Property(e => e.IdMateria).HasColumnName("Id_Materia");

                entity.Property(e => e.Aula)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Seccion)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MateriasEstudiante>(entity =>
            {
                entity.ToTable("Materias_Estudiantes");

                entity.HasIndex(e => e.IdEstudiante, "IX_Materias_Estudiantes_ID_Estudiante");

                entity.HasIndex(e => e.IdMaterias, "IX_Materias_Estudiantes_ID_Materias");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IdEstudiante).HasColumnName("ID_Estudiante");

                entity.Property(e => e.IdMaterias).HasColumnName("ID_Materias");

                entity.HasOne(d => d.IdEstudianteNavigation)
                    .WithMany(p => p.MateriasEstudiantes)
                    .HasForeignKey(d => d.IdEstudiante)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Materias___ID_Es__32E0915F");

                entity.HasOne(d => d.IdMateriasNavigation)
                    .WithMany(p => p.MateriasEstudiantes)
                    .HasForeignKey(d => d.IdMaterias);
            });

            modelBuilder.Entity<MateriasProfesore>(entity =>
            {
                entity.ToTable("Materias_Profesores");

                entity.HasIndex(e => e.IdMaterias, "IX_Materias_Profesores_ID_Materias");

                entity.HasIndex(e => e.IdProfesor, "IX_Materias_Profesores_ID_Profesor");

                entity.HasIndex(e => e.MateriaIdMateria, "IX_Materias_Profesores_MateriaIdMateria");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IdMaterias).HasColumnName("ID_Materias");

                entity.Property(e => e.IdProfesor).HasColumnName("ID_Profesor");

                entity.HasOne(d => d.IdMateriasNavigation)
                    .WithMany(p => p.MateriasProfesoreIdMateriasNavigations)
                    .HasForeignKey(d => d.IdMaterias)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Materias___ID_Ma__398D8EEE");

                entity.HasOne(d => d.IdProfesorNavigation)
                    .WithMany(p => p.MateriasProfesores)
                    .HasForeignKey(d => d.IdProfesor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Materias___ID_Pr__36B12243");

                entity.HasOne(d => d.MateriaIdMateriaNavigation)
                    .WithMany(p => p.MateriasProfesoreMateriaIdMateriaNavigations)
                    .HasForeignKey(d => d.MateriaIdMateria);
            });

            modelBuilder.Entity<Profesor>(entity =>
            {
                entity.HasKey(e => e.IdProfesor);

                entity.ToTable("Profesor");

                entity.Property(e => e.IdProfesor).HasColumnName("ID_Profesor");

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Genero)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasMaxLength(12)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
