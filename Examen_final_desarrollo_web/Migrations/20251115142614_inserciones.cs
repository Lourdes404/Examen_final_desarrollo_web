using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Examen_final_desarrollo_web.Migrations
{
    /// <inheritdoc />
    public partial class inserciones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Clinicas",
                columns: new[] { "Id", "Descripcion", "Nombre" },
                values: new object[,]
                {
                    { 1, null, "Clínica General" },
                    { 2, null, "Clínica de Pediatría" }
                });

            migrationBuilder.InsertData(
                table: "Pacientes",
                columns: new[] { "Id", "DocumentoIdentidad", "Nombre" },
                values: new object[,]
                {
                    { 1, "1234567890101", "Juan Pérez" },
                    { 2, "9876543210101", "María López" }
                });

            migrationBuilder.InsertData(
                table: "Turnos",
                columns: new[] { "Id", "ClinicaId", "Estado", "FechaHora", "PacienteId" },
                values: new object[,]
                {
                    { 1, 1, "Pendiente", new DateTime(2025, 1, 10, 9, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, 2, "Pendiente", new DateTime(2025, 1, 10, 9, 30, 0, 0, DateTimeKind.Unspecified), 2 }
                });

            migrationBuilder.InsertData(
                table: "ReasignacionesTurnos",
                columns: new[] { "Id", "FechaHora", "Motivo", "NuevaClinicaId", "TurnoId" },
                values: new object[] { 1, new DateTime(2025, 1, 10, 8, 30, 0, 0, DateTimeKind.Unspecified), "Clínica saturada", 2, 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ReasignacionesTurnos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Turnos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Clinicas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Pacientes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Turnos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Clinicas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Pacientes",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
