using Backend.Data;
using Microsoft.EntityFrameworkCore;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables()
            .Build();

        var cadenaConexion = configuration.GetConnectionString("DefaultConnection");

        builder.Services.AddDbContext<TiendaContext>(
            options => options.UseNpgsql(cadenaConexion).UseSnakeCaseNamingConvention());

        // CORS
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowSpecificOrigins",
                builder => builder
                    .WithOrigins("http://localhost:5173", "http://localhost:5000", "http://sitioweb.com.ar")
                    .AllowAnyHeader()
                    .AllowAnyMethod());
        });

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseCors("AllowSpecificOrigins");
        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }
}