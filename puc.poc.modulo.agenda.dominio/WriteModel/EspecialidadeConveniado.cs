using System.Collections.Generic;

namespace puc.poc.modulo.agenda.dominio.WriteModel
{
    public class EspecialidadeConveniado : BaseEntity
    {
        public int TempoDuracao { get; set; }

        public List<Agendamento> Agendamentos { get; set; }
    }
}