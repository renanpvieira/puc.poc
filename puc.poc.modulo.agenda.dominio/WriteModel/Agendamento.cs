using System;

namespace puc.poc.modulo.agenda.dominio.WriteModel
{
    public class Agendamento : BaseEntity, ICalculaDataHoraFim
    {
        public DateTime DataHoraInicio { get; set; }

        public DateTime DataHoraFim { get; set; }

        public Associado Associado { get; set; }

        public Conveniado Conveniado { get; set; }

        public EspecialidadeConveniado Especialidade { get; set; }

        public void CalculaDataHoraFim()
        {
            DataHoraFim = DataHoraInicio.AddMinutes(Especialidade.TempoDuracao);
        }
    }
}