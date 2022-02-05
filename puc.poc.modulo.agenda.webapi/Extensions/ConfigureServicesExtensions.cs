using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using puc.poc.modulo.cross.Kafka;

namespace puc.poc.modulo.agenda.webapi
{
    public static class ConfigureServicesExtensions
    {
        public static IServiceCollection AddKafkaBus(this IServiceCollection services)
        {
            return services.InstallKafka("localhost", 9092, "agenda-topic");
        }

        public static IServiceCollection AddSwaggerModule(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Agenda API",
                    Version = "v1",
                    Description = "Api para acesso ao modulo Agenda.",
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
