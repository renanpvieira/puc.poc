using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace puc.poc.modulo.associado.hostservice.readmodel
{
    public class AssociadoReadModelService : IHostedService
    {
        public Task StartAsync(CancellationToken cancellationToken)
        {
            var version = Assembly.GetExecutingAssembly().GetName().Version;
            Console.WriteLine($"Iniciando Associado Read Model Service. Version: {version}");




            Console.WriteLine("Associado Read Model Service Iniciado.");
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
