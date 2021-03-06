using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using puc.poc.modulo.servico.repositorio.readmodel;
using MongoDB.Driver;
using puc.poc.modulo.servico.webapi.Extensions;

namespace puc.poc.modulo.servico.webapi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var mongoClient = new MongoClient("mongodb://root:QliIZ6xIHH3wYveK@localhost:27017");
            services.AddScoped<IMongoDatabase>(_ => mongoClient.GetDatabase("servico-readmodel"));
            services.AddScoped<IServicoRepositorio, ServicoRepositorio>();

            services
                .AddKafkaBus()
                .AddSwaggerModule()
                .AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IHostApplicationLifetime lifetime)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseKafkaBus(lifetime);

            app.UseSwaggerModule();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
