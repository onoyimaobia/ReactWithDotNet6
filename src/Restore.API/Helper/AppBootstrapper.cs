using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Restore.Core.Data;
using Restore.Core.Data.Repository;
using Serilog;

namespace Restore.API.Helper
{
    public static class AppBootsrapper
    {
        public static readonly string  MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public static void InitServices(WebApplicationBuilder builder)
        {
            
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                                    builder =>
                                    {
                                        builder.AllowAnyOrigin()
                                                            .AllowAnyHeader()
                                                            .AllowAnyMethod();
                                    });
            });

            builder.Services.AddControllers();

            // Add services to the container.
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Restore API",
                    Description = "Web APIs Restore product API",
                    Version = "v1"
                });
            });
            // Add a custom scoped service.
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddDbContext<RestoreContext>(options =>
                                                              options.UseSqlServer(builder.Configuration.GetConnectionString("Default"), b => b.MigrationsAssembly("Restore.Core.Data")));
            builder.Host.UseSerilog((ctx, lc) => lc
            .WriteTo.Console()
            .ReadFrom.Configuration(ctx.Configuration));
        }

    }
}