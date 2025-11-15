// Models/Turno.cs
using Examen_final_desarrollo_web.Models;
using System;

namespace Examen_final_desarrollo_web.Models
{
    public class Turno
    {
        public int Id { get; set; }                    // PK

        // FK a Paciente
        public int PacienteId { get; set; }
        public Paciente Paciente { get; set; }

        // FK a Clinica actual
        public int ClinicaId { get; set; }
        public Clinica Clinica { get; set; }

        // Fecha y hora del turno
        public DateTime FechaHora { get; set; }

        // Estado del turno (Pendiente, Atendido, Cancelado, etc.)
        public string Estado { get; set; }

        // Reasignaciones asociadas a este turno
        public ICollection<ReasignacionTurno>? Reasignaciones { get; set; }
    }
}
