using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace puc.poc.modulo.agenda.repositorio.writemodel
{
    
    public class ContextoFactory : IDesignTimeDbContextFactory<Contexto>
    {
        public Contexto CreateDbContext(string[] args)
        {
            
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<Contexto>();

            var serverVersion = new MySqlServerVersion(MySqlServerVersion.LatestSupportedServerVersion);
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            builder.UseMySql(connectionString, serverVersion);

            return new Contexto(builder.Options);
        }
    }
}