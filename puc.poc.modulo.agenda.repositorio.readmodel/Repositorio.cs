using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using puc.poc.modulo.agenda.dominio.ReadModel;

namespace puc.poc.modulo.servico.repositorio.readmodel
{
    public abstract class Repositorio<T> : IRepositorio<T> where T : BaseEntity 
    {
        public readonly IMongoCollection<T> collection;

        public Repositorio(IMongoDatabase database)
        {
            collection = database.GetCollection<T>(typeof(T).Name);
        }

        public async Task<IEnumerable<T>> GetAsync() =>
            await collection.Find(_ => true).ToListAsync();

        public async Task<T> GetAsync(string id) =>
            await collection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task InsertAsync(T objeto) =>
            await collection.InsertOneAsync(objeto);
    }
}