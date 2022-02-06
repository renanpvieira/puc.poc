using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace puc.poc.modulo.financeiro.hostservice.writemodel
{
    public class FinanceiroWriteModelService : IHostedService
    {
        public Task StartAsync(CancellationToken cancellationToken)
        {
            var version = Assembly.GetExecutingAssembly().GetName().Version;
            Console.WriteLine($"Iniciando Financeiro Write Model Service. Version: {version}");

            Console.WriteLine("Agenda Financeiro Model Service Iniciado.");
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}