using System;
using System.Threading.Tasks;
using KafkaFlow;
using KafkaFlow.Serializer;
using KafkaFlow.TypedHandler;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using puc.poc.modulo.associado.hostservice.readmodel.Handlers;

namespace puc.poc.modulo.associado.hostservice.readmodel
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            Console.Title = "Associados ReadModels";

            var host = new HostBuilder()
                .ConfigureServices((hostedContext, services) =>
                {
                    services.AddHostedService<AssociadoReadModelService>();

                    services.AddKafka(
                        kafka => kafka
                            .UseConsoleLog()
                            .AddCluster(
                                cluster => cluster
                                    .WithBrokers(new[] { "localhost:9092" })
                                    .AddConsumer(
                                        consumer => consumer
                                            .Topic("associado-topic")
                                            .WithGroupId("read-print-console-handler") // os consumer tem que ter group id diferentes
                                            .WithBufferSize(100)
                                            .WithWorkersCount(20)
                                            .AddMiddlewares(
                                                middlewares => middlewares
                                                    .AddSerializer<ProtobufNetSerializer>()
                                                    .AddTypedHandlers(h => h.AddHandler<AssociadoCreatedEventHandler>())
                                            )
                                    )
                            )
                    );

                    services.BuildServiceProvider().CreateKafkaBus().StartAsync();
                })
                .Build();
            await host.RunAsync();
        }
    }
}
