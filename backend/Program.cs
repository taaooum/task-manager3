using backend.Services;
using backend.Repositories;
using Microsoft.EntityFrameworkCore;
using backend.Data;
using Npgsql.EntityFrameworkCore.PostgreSQL;

namespace backend
{
    public class Program
    {
        // Main entry point of the application
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Dependency Injection (DI) and Inversion of Control (IoC) Container Configuration

            // DbContext mit PostgreSQL registrieren
            builder.Services.AddDbContext<RepositoryDbContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped<BucketRepository>();
            builder.Services.AddScoped<ItemRepository>(); 

            builder.Services.AddScoped<BucketService>();
            builder.Services.AddScoped<ItemService>();

            builder.Services.AddControllers(); // Add controllers to the DI container to handle API requests

            // Add services for API documentation generation using Swagger
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();



            // Build the application from the configured services
            var app = builder.Build();
            {
                // Middleware Configuration - Set up the HTTP request pipeline

                // If the environment is development, enable Swagger for API documentation
                if (app.Environment.IsDevelopment())
                {
                    app.UseSwagger();               // Enable Swagger middleware
                    app.UseSwaggerUI();            // Enable Swagger UI for user-friendly API interaction
                }
               
                app.UseHttpsRedirection();  // Enable HTTPS redirection for secure communication
                app.UseAuthorization();     // Enable authorization middleware to enforce security policies
                app.MapControllers();       // Map API controllers to the request pipeline
            }

            app.Run();
        }
    }
}

