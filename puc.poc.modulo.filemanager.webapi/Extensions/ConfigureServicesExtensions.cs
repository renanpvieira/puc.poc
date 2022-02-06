using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace puc.poc.modulo.filemanager.webapi.Extensions
{
    public static class ConfigureServicesExtensions
    {
        public static IServiceCollection AddSwaggerModule(this IServiceCollection services)
        {
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "filemanager API",
                    Version = "v1",
                    Description = "Api para acesso ao modulo filemanager.",
                    Contact = new OpenApiContact
                    {
                        Name = "Renan Vieira",
                        Email = "renanvieira@id.uff.br"
                    }
                });
            });

            return services;
        }
    }
}
