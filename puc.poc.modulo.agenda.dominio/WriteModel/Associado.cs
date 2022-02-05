using System.Collections.Generic;

namespace puc.poc.modulo.agenda.dominio.WriteModel
{
    public class Associado :  BaseEntity
    {
        public List<Agendamento> Agendamentos { get; set; }
    }
}