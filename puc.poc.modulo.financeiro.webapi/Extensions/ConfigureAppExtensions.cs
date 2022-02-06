using KafkaFlow;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;

namespace puc.poc.modulo.financeiro.webapi.Extensions
{
    public static class ConfigureAppExtensions
    {
        public static IApplicationBuilder UseSwaggerModule(this IApplicationBuilder app)
        {
            app.UseSwagger();
            
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "FINANCEIRO API V1");
                c.RoutePrefix = string.Empty;
            });

            return app;
        }

        public static IApplicationBuilder UseKafkaBus(this IApplicationBuilder app, IHostApplicationLifetime lifetime)
        {
            lifetime.ApplicationStarted.Register(() =>
                app.ApplicationServices.CreateKafkaBus().StartAsync(lifetime.ApplicationStopped));

            return app;
        }
    }
}