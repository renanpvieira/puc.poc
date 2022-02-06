using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace puc.poc.modulo.financeiro.hostservice.readmodel
{
    public class AgendaReadModelService : IHostedService
    {
        public Task StartAsync(CancellationToken cancellationToken)
        {
            var version = Assembly.GetExecutingAssembly().GetName().Version;
            Console.WriteLine($"Iniciando Financeiro Read Model Service. Version: {version}");

            Console.WriteLine("Agenda Financeiro Model Service Iniciado.");
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
