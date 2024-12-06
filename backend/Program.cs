using Microsoft.EntityFrameworkCore;
using backend.Data;
using backend.Models;
using System.Configuration;

namespace backend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // DI IoC Container Configurations //
            builder.Services.AddControllers();

            // IoC Container Configuration
            var configuration = builder.Configuration;
           
            // add DBcontext to SQL Server
            builder.Services.AddDbContext<TaskManagerDbContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            
            var app = builder.Build();
            {
                // Middleware Configurations - Configure the HTTP request pipeline
                if (app.Environment.IsDevelopment())
                {
                    app.UseSwagger();
                    app.UseSwaggerUI();
                }

                app.UseHttpsRedirection();

                app.UseAuthorization();

                app.MapControllers();
            }
            app.Run();
        }
    }
}
