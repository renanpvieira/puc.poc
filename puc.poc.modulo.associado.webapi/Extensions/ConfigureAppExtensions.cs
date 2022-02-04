using HealthChecks.UI.Client;
using KafkaFlow;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace puc.poc.modulo.associado.webapi.Extensions
{
    public static class ConfigureAppExtensions
    {
        public static IApplicationBuilder UseHealthChecksMonitor(this IApplicationBuilder app)
        {
            app.UseHealthChecks("/healthchecks-data-ui", new HealthCheckOptions
            {
                Predicate = _ => true,
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });

            app.UseHealthChecksUI(options =>
            {
                options.UIPath = "/monitor";
            });

            return app;
        }

        public static IApplicationBuilder UseKafkaBus(this IApplicationBuilder app, IHostApplicationLifetime lifetime)
        {
            lifetime.ApplicationStarted.Register(() => 
                app.ApplicationServices.CreateKafkaBus().StartAsync(lifetime.ApplicationStopped));

            return app;
        }

        public static IApplicationBuilder UseControllers(this IApplicationBuilder app)
        {
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            return app;
        }

        public static IApplicationBuilder UseDeveloperException(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            return app;
        }

        public static IApplicationBuilder UseRouter(this IApplicationBuilder app)
        {
            app.UseRouting();
            return app;
        }

        public static IApplicationBuilder UseSwaggerModule(this IApplicationBuilder app)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ASSOCIADO API V1");
                c.RoutePrefix = string.Empty;
            });

            return app;
        }
    }
}