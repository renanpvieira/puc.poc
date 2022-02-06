using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using puc.poc.modulo.servico.hostservice.readmodel.Extensions;
using puc.poc.modulo.servico.repositorio.readmodel;

namespace puc.poc.modulo.servico.hostservice.readmodel
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            Console.Title = "Servico ReadModels";

            var host = new HostBuilder()
                .ConfigureServices((hostedContext, services) =>
                {
                    services.AddHostedService<ServicoReadModelService>();

                    var mongoClient = new MongoClient("mongodb://root:QliIZ6xIHH3wYveK@localhost:27017");
                    services.AddScoped<IMongoDatabase>(_ => mongoClient.GetDatabase("servico-readmodel"));
                    services.AddScoped<IServicoRepositorio, ServicoRepositorio>();
                    services.AddScoped<IOrdemServicoRepositorio, OrdemServicoRepositorio>();

                    services.AddKafkaBus();
                })
                .Build();

            await host.RunAsync();
        }
    }
}
