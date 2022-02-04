using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace puc.poc.modulo.associado.hostservice.writemodel
{
    public class AssociadoWriteModelService : IHostedService
    {
        public Task StartAsync(CancellationToken cancellationToken)
        {
            var version = Assembly.GetExecutingAssembly().GetName().Version;
            Console.WriteLine($"Iniciando Associado Write Model Service. Version: {version}");




            Console.WriteLine("Associado Write Model Service Iniciado.");
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
