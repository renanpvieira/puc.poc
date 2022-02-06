using System.Collections.Generic;

namespace puc.poc.modulo.servico.dominio.WriteModel
{
    public class Associado :  BaseEntity
    {
        public List<OrdemServico> Servicos { get; set; }

        public AssociadoTipo TipoPlano { get; set; }

        public AssociadoModelo ModeloPlano { get; set; }
    }
}