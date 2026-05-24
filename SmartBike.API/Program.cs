using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SmartBike.API.Servicios;
namespace SmartBike.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<SmartBikeAPIContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("SmartBikeAPIContext") ?? throw new InvalidOperationException("Connection string 'SmartBikeAPIContext' not found.")));
          

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Registrar los Servicios de Sostenibilidad e Identidad en el contenedor IOC
            builder.Services.AddScoped<IUsuarioServicio, UsuarioServicio>();
            builder.Services.AddScoped<ITipoUsuarioServicio, TipoUsuarioServicio>();
            builder.Services.AddScoped<ITipoTransporteServicio, TipoTransporteServicio>();
            builder.Services.AddScoped<ICamaraServicio, CamaraServicio>();
            builder.Services.AddScoped<IRegistroDiarioServicio, RegistroDiarioServicio>();
            builder.Services.AddScoped<IHistorialServicio, HistorialServicio>();
            builder.Services.AddScoped<IReporteServicio, ReporteServicio>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
