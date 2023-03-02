using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text.Json.Serialization;
using TaskTracker.API.Services;
using static TaskTracker.API.Features.Tasks.AddTask;
using static TaskTracker.API.Features.Tasks.AddTask.AddTaskCommandHandler;

namespace TaskTracker.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddSingleton<ITaskService, TaskService>();

            builder.Services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);
            });

            builder.Services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            var xmlFile = $"{GetAssemblyName()}.xml";
            var pathToDoc = Path.Combine(AppContext.BaseDirectory, "TaskTracker.Api.xml");
            builder.Services.AddSwaggerGen(config =>
            {
                config.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Task Tracker Demo",
                    Version = "1.0",
                    Description = "Demo showcase of using NSWAG to generate a client proxy of this API",
                    TermsOfService = new Uri("https://terms.bhp.com"),
                    Contact = new OpenApiContact
                    {
                        Name = "Planning Team",
                        Email = "planning.team@bhp.com",
                        Url = new Uri("https://planning.bhp.com")
                    }
                });


                config.IncludeXmlComments(pathToDoc);
            });

            builder.Services.AddCors(o => o.AddPolicy("default", builder =>
            {
                builder.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader()
                          .AllowCredentials()
                          .WithOrigins("http://localhost:3000");

            }));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors("default");
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }

        private static string? GetAssemblyName()
        {
            return Assembly.GetExecutingAssembly().GetName().Name;
        }
    }
}