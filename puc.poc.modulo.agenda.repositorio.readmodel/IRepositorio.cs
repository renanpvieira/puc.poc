using System.Collections.Generic;
using System.Threading.Tasks;
using puc.poc.modulo.agenda.dominio.ReadModel;

namespace puc.poc.modulo.agenda.repositorio.readmodel
{
    public interface IRepositorio<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAsync();
        Task<T> GetAsync(string id);
        Task InsertAsync(T objeto);
    }
}