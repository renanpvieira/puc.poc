using System;
using System.Linq;
using KafkaFlow;
using KafkaFlow.TypedHandler;
using Microsoft.Extensions.DependencyInjection;
using puc.poc.modulo.cross.Kafka;

namespace puc.poc.modulo.financeiro.hostservice.readmodel.Extensions
{
    public static class ConfigureServicesExtensions
    {
        public static IServiceCollection AddKafkaBus(this IServiceCollection services)
        {
            var consumerTypes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(s => typeof(IMessageHandler).IsAssignableFrom(s))
                .ToArray();

            services.InstallKafka("localhost", 9092, "financeiro-topic", consumerTypes, "financeiro-read-console");

            services.BuildServiceProvider().CreateKafkaBus().StartAsync();

            return services;
        }
    }
}
