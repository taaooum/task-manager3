using backend.Services;
using backend.Repositories;
using Microsoft.EntityFrameworkCore;

namespace backend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Dependency Injection (DI) and Inversion of Control (IoC) Container Configuration

            // A new Context for Postgresql Database
            builder.Services.AddDbContext<DataContextService>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped<BucketRepository>();
            builder.Services.AddScoped<ItemRepository>(); 

            builder.Services.AddScoped<BucketService>();
            builder.Services.AddScoped<ItemService>();

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();



            // Build the application from the configured services
            var app = builder.Build();
            {
                // Middleware Configuration - Set up the HTTP request pipeline

                // If the environment is development, enable Swagger for API documentation
                if (app.Environment.IsDevelopment())
                {
                    app.UseSwagger();            
                    app.UseSwaggerUI();
                }
               
                app.UseHttpsRedirection();  // Enable HTTPS redirection for secure communication
                app.UseAuthorization();     // Enable authorization middleware to enforce security policies
                app.MapControllers();       // Map API controllers to the request pipeline
            }

            app.Run();
        }
    }
}

