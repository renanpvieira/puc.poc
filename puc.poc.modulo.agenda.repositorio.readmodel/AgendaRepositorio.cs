using MongoDB.Driver;
using puc.poc.modulo.agenda.dominio.ReadModel;

namespace puc.poc.modulo.agenda.repositorio.readmodel
{
    public class AgendaRepositorio : Repositorio<Agendamento>, IAgendaRepositorio
    {
        public AgendaRepositorio(IMongoDatabase database) : base(database)
        {
           
        }
    }
}