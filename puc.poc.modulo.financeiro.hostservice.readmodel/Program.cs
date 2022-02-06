using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using puc.poc.modulo.financeiro.hostservice.readmodel.Extensions;
using MongoDB.Driver;
using puc.poc.modulo.financeiro.repositorio.readmodel;

namespace puc.poc.modulo.financeiro.hostservice.readmodel
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            Console.Title = "Financeiro ReadModels";

            var host = new HostBuilder()
                .ConfigureServices((hostedContext, services) =>
                {
                    services.AddHostedService<AgendaReadModelService>();

                    var mongoClient = new MongoClient("mongodb://root:QliIZ6xIHH3wYveK@localhost:27017");
                    services.AddScoped<IMongoDatabase>(_ => mongoClient.GetDatabase("financeiro"));
                    services.AddScoped<IBoletoRepositorio, BoletoRepositorio>();

                    services.AddKafkaBus();
                })
                .Build();

            await host.RunAsync();
        }
    }
}