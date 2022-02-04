using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using puc.poc.modulo.associado.webapi.Extensions;

namespace puc.poc.modulo.associado.webapi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddHealthChecksMonitor()
                .AddKafkaBus()
                .AddSwaggerModule()
                .AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IHostApplicationLifetime lifetime)
        {
            app.UseDeveloperException(env)
               .UseRouter()
               .UseHealthChecksMonitor()
               .UseKafkaBus(lifetime)
               .UseSwaggerModule()
               .UseControllers();
        }
    }
}