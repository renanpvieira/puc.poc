using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using puc.poc.modulo.associado.hostservice.writemodel.Extensions;

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