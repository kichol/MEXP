using MediaExpert.Products.Api.Middleware;
using MediaExpert.Products.Api.Utility;
using MediaExpert.Products.Application;
using MediaExpert.Products.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Serilog;


namespace MediaExpert.Products.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            AddSwagger(builder.Services);

            builder.Services.AddApplicationServices();
            builder.Services.AddPersistenceServices(builder.Configuration);

            builder.Services.AddHttpContextAccessor();

            builder.Services.AddControllers();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("Open", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            });
           
        
            builder.Host.UseSerilog((ctx, lc) => lc
                .WriteTo.File("logs/Mylog.log", rollingInterval: RollingInterval.Day));

            

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "GloboTicket Ticket Management API");
                });
            }

            app.UseHttpsRedirection();

            //app.UseRouting();

            app.UseAuthentication();

            app.UseCustomExceptionHandler();

            app.UseCors("Open");

            app.UseAuthorization();

            app.MapControllers();


            app.Run();
        }

        private static void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {


                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "GloboTicket Ticket Management API",

                });

                c.OperationFilter<FileResultContentTypeOperationFilter>();
            });
        }
       
    }
}