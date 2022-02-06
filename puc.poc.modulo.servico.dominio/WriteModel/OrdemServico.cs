using System;

namespace puc.poc.modulo.servico.dominio.WriteModel
{
    public class OrdemServico : BaseEntity
    {
        public DateTime DataServico { get; set; }

        public Associado Associado { get; set; }

        public Servico Servico { get; set; }

        public Colaborador Colaborador { get; set; }

        public string Texto { get; set; }
    }
}
