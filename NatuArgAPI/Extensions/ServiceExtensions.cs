using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NatuArgAPI.Extensions
{
    public static class ServiceExtensions
    {
        #region Configuraciones de Swagger
        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options => {
                options.SwaggerDoc("NatuArgOpenApiParques",
                        new Microsoft.OpenApi.Models.OpenApiInfo()
                        {
                            Title = "NatuARG API Parques",
                            Version = "1.0",
                            Description = "Web API para pagina de Parques Nacionales de Argentina.",
                            Contact = new Microsoft.OpenApi.Models.OpenApiContact()
                            {
                                Email = "josernr25@gmail.com",
                                Name = "Jose Molina",
                                Url = new Uri("https://github.com/josernr25")
                            },
                            License = new Microsoft.OpenApi.Models.OpenApiLicense()
                            {
                                Name = "MIT License",
                                Url = new Uri("https://es.wikipedia.org/wiki/Licencia_MIT")
                            }
                        });
            });

            services.AddSwaggerGen(options => {
                options.SwaggerDoc("NatuArgOpenApiAtracciones",
                        new Microsoft.OpenApi.Models.OpenApiInfo()
                        {
                            Title = "NatuARG API Atracciones",
                            Version = "1.0",
                            Description = "Web API para pagina de Parques Nacionales de Argentina.",
                            Contact = new Microsoft.OpenApi.Models.OpenApiContact()
                            {
                                Email = "josernr25@gmail.com",
                                Name = "Jose Molina",
                                Url = new Uri("https://github.com/josernr25")
                            },
                            License = new Microsoft.OpenApi.Models.OpenApiLicense()
                            {
                                Name = "MIT License",
                                Url = new Uri("https://es.wikipedia.org/wiki/Licencia_MIT")
                            }
                        });
            });
        }
        #endregion
    }
}
