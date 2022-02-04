using System;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using KafkaFlow;
using KafkaFlow.Serializer;
using KafkaFlow.TypedHandler;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using puc.poc.modulo.associado.hostservice.writemodel.Extensions;
using puc.poc.modulo.associado.hostservice.writemodel.Handlers;
using puc.poc.modulo.cross.Kafka;
using puc.poc.modulo.cross.Kafka.Interfaces;


namespace puc.poc.modulo.associado.hostservice.writemodel
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            Console.Title = "Associados WriteModels";
            
            var host = new HostBuilder()
                .ConfigureServices((hostedContext, services) =>
                {
                    services.AddHostedService<AssociadoWriteModelService>();
                    services.AddKafkaBus();
                })
                .Build();
            
            await host.RunAsync();
        }
    }
}