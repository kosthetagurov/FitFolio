using FitFolio.Data.DependencyInjection;
using FitFolio.Domain.DependencyInjection;
using Serilog;

namespace FitFolio.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Configuration
            .AddJsonFile("serilog.json", optional: false, reloadOnChange: true);

        builder.Host.UseSerilog((context, services, configuration) =>
        {
            configuration
                .ReadFrom.Configuration(context.Configuration)    
                .ReadFrom.Services(services)                     
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day);
        });
        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddFitFolioData(new DataAccessLayerOptions(builder.Configuration.GetConnectionString("DefaultConnection")));
        builder.Services.AddDomainServices();

        var app = builder.Build();

        app.UseSerilogRequestLogging();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseStaticFiles(); 
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.DocumentTitle = "FitFolio.Api";
                c.SwaggerEndpoint("/swagger/v1/swagger.json", $"FitFolio.Api");
                c.InjectStylesheet("custom.css");
            });
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
