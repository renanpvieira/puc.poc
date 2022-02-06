using System.Collections.Generic;

namespace puc.poc.modulo.servico.dominio.WriteModel
{
    public class Colaborador :  BaseEntity
    {
        public List<OrdemServico> Servicos { get; set; }
    }
}