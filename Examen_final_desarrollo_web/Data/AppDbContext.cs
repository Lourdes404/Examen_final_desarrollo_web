using Microsoft.EntityFrameworkCore;
using Examen_final_desarrollo_web.Models;

namespace Examen_final_desarrollo_web.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Clinica> Clinicas { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Turno> Turnos { get; set; }
        public DbSet<ReasignacionTurno> ReasignacionesTurnos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ⚠️ Desactivar el delete cascade para evitar "multiple cascade paths"
            modelBuilder.Entity<ReasignacionTurno>()
                .HasOne(r => r.Turno)
                .WithMany(t => t.Reasignaciones)
                .HasForeignKey(r => r.TurnoId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ReasignacionTurno>()
                .HasOne(r => r.NuevaClinica)
                .WithMany()
                .HasForeignKey(r => r.NuevaClinicaId)
                .OnDelete(DeleteBehavior.Restrict);

            // Clínicas
            modelBuilder.Entity<Clinica>().HasData(
                new Clinica { Id = 1, Nombre = "Clínica General" },
                new Clinica { Id = 2, Nombre = "Clínica de Pediatría" }
            );

            // Pacientes
            modelBuilder.Entity<Paciente>().HasData(
                new Paciente { Id = 1, Nombre = "Juan Pérez", DocumentoIdentidad = "1234567890101" },
                new Paciente { Id = 2, Nombre = "María López", DocumentoIdentidad = "9876543210101" }
            );

            // Turnos
            modelBuilder.Entity<Turno>().HasData(
                new Turno
                {
                    Id = 1,
                    PacienteId = 1,
                    ClinicaId = 1,
                    FechaHora = new DateTime(2025, 01, 10, 9, 0, 0),
                    Estado = "Pendiente"
                },
                new Turno
                {
                    Id = 2,
                    PacienteId = 2,
                    ClinicaId = 2,
                    FechaHora = new DateTime(2025, 01, 10, 9, 30, 0),
                    Estado = "Pendiente"
                }
            );

            // Reasignaciones (opcional, solo para tener un registro)
            modelBuilder.Entity<ReasignacionTurno>().HasData(
                new ReasignacionTurno
                {
                    Id = 1,
                    TurnoId = 1,
                    NuevaClinicaId = 2,
                    Motivo = "Clínica saturada",
                    FechaHora = new DateTime(2025, 01, 10, 8, 30, 0)
                }
            );
        }
    }
}
