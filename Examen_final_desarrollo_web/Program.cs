using Examen_final_desarrollo_web.Data;
using Microsoft.EntityFrameworkCore;

namespace Examen_final_desarrollo_web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // MVC con Vistas
            builder.Services.AddControllersWithViews();

            // EF Core
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
            );

            // Swagger (solo si querés mantenerlo)
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            // ⭐ Ruta MVC
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Turnos}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
