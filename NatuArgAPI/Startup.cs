using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NatuArgAPI.Data;
using NatuArgAPI.Data.Contracts;
using NatuArgAPI.Data.Repository;
using AutoMapper;
using Swashbuckle;
using System.Reflection;
using System.IO;

namespace NatuArgAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<NatuArgDbContext>
                (options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddAutoMapper(typeof(Startup));
            services.AddSwaggerGen( options => {
                options.SwaggerDoc("NatuArgOpenApi",
                        new Microsoft.OpenApi.Models.OpenApiInfo() { 
                            Title = "NatuARG API", 
                            Version = "1.0",
                            Description = "Web API para pagina de Parques Nacionales de Argentina.",
                            Contact = new Microsoft.OpenApi.Models.OpenApiContact() {
                                Email = "josernr25@gmail.com",
                                Name = "Jose Molina",
                                Url = new Uri("https://github.com/josernr25")
                            },
                            License = new Microsoft.OpenApi.Models.OpenApiLicense() {
                                Name = "MIT License",
                                Url = new Uri("https://es.wikipedia.org/wiki/Licencia_MIT")
                            }
                        });
            });

            //Dependencias
            services.AddScoped<IParqueRepository, ParqueRepository>();
            services.AddScoped<IAtraccionRepository, AtraccionRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();

            app.UseSwaggerUI( options => {
                options.SwaggerEndpoint("/swagger/NatuArgOpenApi/swagger.json", "NatuARG API");
                options.RoutePrefix = "";
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
