// Models/Paciente.cs
namespace Examen_final_desarrollo_web.Models
{
    public class Paciente
    {
        public int Id { get; set; }                // PK
        public string Nombre { get; set; }         // Nombre del paciente
        public string? DocumentoIdentidad { get; set; } // DPI / No. expediente (opcional)

        // Relación: un paciente puede tener muchos turnos
        public ICollection<Turno>? Turnos { get; set; }
    }
}
