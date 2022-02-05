using System.Collections.Generic;

namespace puc.poc.modulo.agenda.dominio.WriteModel
{
    public class Conveniado : BaseEntity
    {
        public List<Agendamento> Agendamentos { get; set; }
    }
}