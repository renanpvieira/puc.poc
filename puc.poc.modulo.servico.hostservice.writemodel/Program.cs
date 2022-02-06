using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using puc.poc.modulo.agenda.hostservice.writemodel;
using puc.poc.modulo.agenda.hostservice.writemodel.Extensions;
using Microsoft.EntityFrameworkCore;
using puc.poc.modulo.servico.repositorio.writemodel;

namespace puc.poc.modulo.servico.hostservice.writemodel
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            Console.Title = "Servico WriteModels";

            var host = new HostBuilder()
                .ConfigureServices((hostedContext, services) =>
                {
                    services.AddHostedService<ServicoWriteModelService>();

                    var serverVersion = new MySqlServerVersion(MySqlServerVersion.LatestSupportedServerVersion);
                    var connectionString = "Server=127.0.0.1;Port=3306;Database=servico;Uid=root;Pwd=Hkm25gRhan19JGWq;";
                    services.AddDbContextPool<Contexto>(options => options.UseMySql(connectionString, serverVersion));
                    services.AddScoped<DbContext, Contexto>();

                    services.AddKafkaBus();
                })
                .Build();

            await host.RunAsync();
        }
    }
}
