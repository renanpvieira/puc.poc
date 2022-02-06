using System.Collections.Generic;
using System.Threading.Tasks;
using puc.poc.modulo.financeiro.dominio.ReadModel;

namespace puc.poc.modulo.financeiro.repositorio.readmodel
{
    public interface IRepositorio<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAsync();
        Task<T> GetAsync(string id);
        Task InsertAsync(T objeto);
    }
}