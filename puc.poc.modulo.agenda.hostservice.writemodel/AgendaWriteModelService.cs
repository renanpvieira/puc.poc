using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace puc.poc.modulo.agenda.hostservice.writemodel
{
    public class AgendaWriteModelService : IHostedService
    {
        public Task StartAsync(CancellationToken cancellationToken)
        {
            var version = Assembly.GetExecutingAssembly().GetName().Version;
            Console.WriteLine($"Iniciando Agenda Write Model Service. Version: {version}");

            Console.WriteLine("Agenda Write Model Service Iniciado.");
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}