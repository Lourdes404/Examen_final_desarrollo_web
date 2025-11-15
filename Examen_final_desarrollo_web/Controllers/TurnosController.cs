using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Examen_final_desarrollo_web.Data;
using Examen_final_desarrollo_web.Models;
using System;
using System.Threading.Tasks;
using System.Linq;

public class TurnosController : Controller
{
    private readonly AppDbContext _context;

    public TurnosController(AppDbContext context)
    {
        _context = context;
    }

    // LISTADO DE TURNOS
    public async Task<IActionResult> Index()
    {
        var turnos = await _context.Turnos
            .Include(t => t.Clinica)
            .Include(t => t.Paciente) // si lo tienes
            .ToListAsync();

        ViewBag.Clinicas = await _context.Clinicas.ToListAsync();
        return View(turnos);
    }

    [HttpPost]
    public async Task<IActionResult> Reasignar(int TurnoId, int NuevaClinicaId, string Motivo)
    {
        Console.WriteLine($">>> TurnoId recibido: {TurnoId}");
        if (string.IsNullOrWhiteSpace(Motivo))
        {
            TempData["Error"] = "El motivo de la reasignación es obligatorio.";
            return RedirectToAction(nameof(Index));
        }

        var turno = await _context.Turnos.FindAsync(TurnoId);
        if (turno == null)
        {
            return NotFound();
        }

        // Registrar la reasignación
        var reasignacion = new ReasignacionTurno
        {
            TurnoId = TurnoId,
            NuevaClinicaId = NuevaClinicaId,
            Motivo = Motivo,
            FechaHora = DateTime.Now
        };

        // Actualizar la clínica del turno
        turno.ClinicaId = NuevaClinicaId;

        _context.ReasignacionesTurnos.Add(reasignacion);
        _context.Turnos.Update(turno);
        await _context.SaveChangesAsync();

        TempData["Mensaje"] = "Turno reasignado correctamente.";
        return RedirectToAction(nameof(Index));
    }
}
