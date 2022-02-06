using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MongoDB.Driver;
using puc.poc.modulo.agenda.hostservice.readmodel.Extensions;
using puc.poc.modulo.agenda.repositorio.readmodel;

namespace puc.poc.modulo.agenda.hostservice.readmodel
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            Console.Title = "Agenda ReadModels";

            var host = new HostBuilder()
                .ConfigureServices((hostedContext, services) =>
                {
                    services.AddHostedService<AgendaReadModelService>();

                    var mongoClient = new MongoClient("mongodb://root:QliIZ6xIHH3wYveK@localhost:27017");
                    services.AddScoped<IMongoDatabase>(_ => mongoClient.GetDatabase("agenda"));
                    services.AddScoped<IAgendaRepositorio, AgendaRepositorio>();

                    services.AddKafkaBus();
                })
                .Build();

            await host.RunAsync();
        }
    }
}
