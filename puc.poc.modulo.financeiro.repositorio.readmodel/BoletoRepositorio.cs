using MongoDB.Driver;
using puc.poc.modulo.financeiro.dominio.ReadModel;

namespace puc.poc.modulo.financeiro.repositorio.readmodel
{
    public class BoletoRepositorio : Repositorio<Boleto>, IBoletoRepositorio
    {
        public BoletoRepositorio(IMongoDatabase database) : base(database)
        {
           
        }
    }
}