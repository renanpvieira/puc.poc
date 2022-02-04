using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using KafkaFlow;
using KafkaFlow.Configuration;
using KafkaFlow.Serializer;
using KafkaFlow.TypedHandler;
using Microsoft.Extensions.DependencyInjection;
using puc.poc.modulo.cross.Kafka.Interfaces;

namespace puc.poc.modulo.cross.Kafka
{
    public static class KafkaInstaller
    {
        public static IServiceCollection InstallKafka(this IServiceCollection services, string host, int port, string topic)
            => InstallKafka(services, host, port, topic, new Type[0], Guid.NewGuid().ToString());
        
        public static IServiceCollection InstallKafka(this IServiceCollection services, string host, int port, string topic, Type[] types, string groupId)
        {
            services.AddSingleton<IMessagesProducer, MessagesProducer>();

            /*
            Action<IConsumerConfigurationBuilder> consumer = c =>
            {
                c.Topic("")
                    .WithGroupId("")
                    ;
            };*/

            services.AddKafka(
                kafka => kafka
                    .UseConsoleLog()
                    .AddCluster(
                        cluster => cluster
                            .WithBrokers(new[] { $"{host}:{port}" })
                            .AddConsumer(
                                consumer => consumer
                                    .Topic(topic)
                                    .WithGroupId(groupId)
                                    .WithBufferSize(100)
                                    .WithWorkersCount(20)
                                    .AddMiddlewares(
                                        middlewares => middlewares
                                            .AddSerializer<ProtobufNetSerializer>()
                                            .AddTypedHandlers(h => h.AddHandlers(types))
                                    )
                            ).AddProducer<MessagesProducer>(producer => producer
                                .DefaultTopic(topic)
                                .AddMiddlewares(middlewares =>
                                    middlewares.AddSerializer<ProtobufNetSerializer>()
                                )
                            )
                    )
            );

            return services;
        }
    }
}