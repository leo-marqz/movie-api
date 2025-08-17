
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace MovieAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            //-------------------------------
            builder.Services.AddRouting((options)=>options.LowercaseUrls = true);
            builder.Services.AddControllers();
            //builder.Services.AddOpenApi();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddAutoMapper(typeof(Program));

            builder.Services.AddDbContext<ApplicationDbContext>((options) =>
            {
                options.UseSqlServer("name=DefaultConnection");
            });

            builder.Services.AddOutputCache((options) =>
            {
                options.DefaultExpirationTimeSpan = TimeSpan.FromSeconds(30);
            });

            var allowedOrigins = builder.Configuration.GetValue<string>("AllowedOrigins")!.Split(',');

            builder.Services.AddCors((options) =>
            {
                options.AddDefaultPolicy((corsOptions) =>
                {
                    corsOptions.WithOrigins(allowedOrigins)
                                .AllowAnyMethod()
                                .AllowAnyHeader()
                                .WithExposedHeaders("x-total-records");
                });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                //app.MapOpenApi();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseCors();
            app.UseOutputCache();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
