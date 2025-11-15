// Models/ReasignacionTurno.cs
using System;

namespace Examen_final_desarrollo_web.Models
{
    public class ReasignacionTurno
    {
        public int Id { get; set; }          // PK

        // Turno que se está reasignando
        public int TurnoId { get; set; }
        public Turno Turno { get; set; }

        // Nueva clínica asignada
        public int NuevaClinicaId { get; set; }
        public Clinica NuevaClinica { get; set; }

        // Motivo de la reasignación (OBLIGATORIO en el formulario)
        public string Motivo { get; set; }

        // Fecha y hora en que se realizó la reasignación
        public DateTime FechaHora { get; set; }
    }
}
