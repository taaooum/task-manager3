using Microsoft.EntityFrameworkCore;
using backend.Models;
using backend.Data;

namespace backend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            { 
                // DI IoC Container Configurations //

                builder.Services.AddControllers();
                builder.Services.AddDbContext<TaskManagerDbContext>(opt =>
                    opt.UseInMemoryDatabase("TaskManager"));

                builder.Services.AddEndpointsApiExplorer();
                builder.Services.AddSwaggerGen();
            }

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
