// Models/Clinica.cs
namespace Examen_final_desarrollo_web.Models
{
    public class Clinica
    {
        public int Id { get; set; }              // PK
        public string Nombre { get; set; }       // Nombre de la clínica
        public string? Descripcion { get; set; } // Opcional

        // Relación: una clínica tiene muchos turnos
        public ICollection<Turno>? Turnos { get; set; }
    }
}
