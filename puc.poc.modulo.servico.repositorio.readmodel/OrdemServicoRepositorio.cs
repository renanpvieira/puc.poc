using MongoDB.Driver;
using puc.poc.modulo.servico.dominio.ReadModel;

namespace puc.poc.modulo.servico.repositorio.readmodel
{
    public class OrdemServicoRepositorio : Repositorio<OrdemServico>, IOrdemServicoRepositorio
    {
        public OrdemServicoRepositorio(IMongoDatabase database) : base(database)
        {
           
        }
    }
}