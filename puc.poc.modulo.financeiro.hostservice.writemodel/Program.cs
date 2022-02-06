using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;
using puc.poc.modulo.agenda.hostservice.writemodel.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using puc.poc.modulo.financeiro.repositorio.writemodel;

namespace puc.poc.modulo.financeiro.hostservice.writemodel
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            Console.Title = "Financeiro WriteModels";

            var host = new HostBuilder()
                .ConfigureServices((hostedContext, services) =>
                {
                    services.AddHostedService<FinanceiroWriteModelService>();

                    var serverVersion = new MySqlServerVersion(MySqlServerVersion.LatestSupportedServerVersion);
                    var connectionString = "Server=127.0.0.1;Port=3306;Database=financeiro;Uid=root;Pwd=Hkm25gRhan19JGWq;";
                    services.AddDbContextPool<Contexto>(options => options.UseMySql(connectionString, serverVersion));
                    services.AddScoped<DbContext, Contexto>();

                    services.AddKafkaBus();
                })
                .Build();

            await host.RunAsync();
        }
    }
}
