using System.Collections.Generic;

namespace puc.poc.modulo.financeiro.dominio.WriteModel
{
    public class Associado :  BaseEntity
    {
        public List<Boleto> Boletos { get; set; }
    }
}