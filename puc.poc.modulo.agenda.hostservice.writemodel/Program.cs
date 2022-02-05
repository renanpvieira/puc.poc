using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using puc.poc.modulo.agenda.hostservice.writemodel.Extensions;
using puc.poc.modulo.agenda.repositorio.writemodel;

namespace puc.poc.modulo.agenda.hostservice.writemodel
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            Console.Title = "Agenda WriteModels";

            var host = new HostBuilder()
                .ConfigureServices((hostedContext, services) =>
                {
                    services.AddHostedService<AgendaWriteModelService>();

                    var serverVersion = new MySqlServerVersion(MySqlServerVersion.LatestSupportedServerVersion);
                    var connectionString = "Server=127.0.0.1;Port=3306;Database=agenda;Uid=root;Pwd=Hkm25gRhan19JGWq;";
                    services.AddDbContextPool<Contexto>(options => options.UseMySql(connectionString, serverVersion));
                    services.AddScoped<DbContext, Contexto>();
                    
                    services.AddKafkaBus();
                })
                .Build();

            await host.RunAsync();
        }
    }
}
