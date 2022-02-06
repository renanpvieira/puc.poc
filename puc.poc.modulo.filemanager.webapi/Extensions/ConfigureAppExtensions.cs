using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;

namespace puc.poc.modulo.filemanager.webapi.Extensions
{
    public static class ConfigureAppExtensions
    {
        public static IApplicationBuilder UseSwaggerModule(this IApplicationBuilder app)
        {
            app.UseSwagger();
            
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "FILEMANAGER API V1");
                c.RoutePrefix = string.Empty;
            });

            return app;
        }
    }
}