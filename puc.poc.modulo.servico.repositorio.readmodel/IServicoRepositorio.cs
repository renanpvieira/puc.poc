using System.Collections.Generic;
using System.Threading.Tasks;
using puc.poc.modulo.servico.dominio.ReadModel;

namespace puc.poc.modulo.servico.repositorio.readmodel
{
    public interface IServicoRepositorio : IRepositorio<Servico>
    {
        Task<IEnumerable<Servico>> GetByTipoAsync(string tipo);
    }
}