using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using RPSLS.Application;
using RPSLS.Infrastructure;
using RPSLS.Persistence;
using RPSLS.Presentation;
using RPSLS.Presentation.Endpoints;
using Serilog;
namespace RPSLS.Api
{
    public partial class Program
    {
        public static int Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddTransient<GlobalExceptionHandlingMiddleware>();

            // Add services to the container.
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services
                .AddPersistence(builder.Configuration)
                .AddInfrastructure()
                .AddApplication()
                .AddPresentation();

            builder.Host.UseSerilog((context, configuration) =>
                configuration.ReadFrom.Configuration(context.Configuration));

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                //app.ApplyMigrations();
            }



            app.UseSerilogRequestLogging();
            app.UseMiddleware<GlobalExceptionHandlingMiddleware>();
            app.AddGameModule();
            app.AddScoreboardModule();
            app.UseHttpsRedirection();
            app.MapHealthChecks("health", new HealthCheckOptions
            {
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });
            app.Run();
            
            return 0;
        }
    }
}


    

