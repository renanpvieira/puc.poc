using System.Collections.Generic;

namespace puc.poc.modulo.servico.dominio.WriteModel
{
    public class Servico : BaseEntity
    {
        public string Descricao { get; set; }

        public double ValorPago { get; set; }

        public double ValorCobrado { get; set; }

        public ServicoTipo Tipo { get; set; }

        public List<OrdemServico> Servicos { get; set; }
    }
}
