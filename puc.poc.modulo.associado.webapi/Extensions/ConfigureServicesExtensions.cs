using Confluent.Kafka;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using puc.poc.modulo.cross.Kafka;

namespace puc.poc.modulo.associado.webapi.Extensions
{
    public static class ConfigureServicesExtensions
    {
        public static IServiceCollection AddHealthChecksMonitor(this IServiceCollection services)
        {
            services
                .AddHealthChecksUI()
                .AddInMemoryStorage();

            services.AddHealthChecks()
                .AddMySql("Server=127.0.0.1;Port=3306;Uid=root;Pwd=Hkm25gRhan19JGWq;", "Mysql")
                .AddMongoDb("mongodb://root:QliIZ6xIHH3wYveK@localhost:27017", name: "Mongo")
                .AddKafka(new ProducerConfig { BootstrapServers = "localhost:9092" }, name: "Kafka");

            services.AddHealthChecksUI();

            return services;
        }

        public static IServiceCollection AddKafkaBus(this IServiceCollection services)
        {
            return services.InstallKafka("localhost", 9092, "associado-topic");
        }

        public static IServiceCollection AddSwaggerModule(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Associado API",
                    Version = "v1",
                    Description = "Api para acesso ao modulo Associado.",
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
