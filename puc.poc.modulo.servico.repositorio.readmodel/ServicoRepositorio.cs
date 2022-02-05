using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using puc.poc.modulo.servico.dominio.ReadModel;

namespace puc.poc.modulo.servico.repositorio.readmodel
{
    public class ServicoRepositorio : Repositorio<Servico>, IServicoRepositorio
    {
        public ServicoRepositorio(IMongoDatabase database) : base(database)
        {
           
        }

        public async Task<IEnumerable<Servico>> GetByTipoAsync(string tipo) => 
            await collection.Find(x => x.Tipo == tipo).ToListAsync();
    }
}