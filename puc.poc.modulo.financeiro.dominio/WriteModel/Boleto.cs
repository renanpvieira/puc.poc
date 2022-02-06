using System;

namespace puc.poc.modulo.financeiro.dominio.WriteModel
{
    public class Boleto : BaseEntity
    {
        public DateTime DataEmissao { get; set; }
        public DateTime DataVencimento { get; set; }
        public double Valor { get; set; }
        public string Banco { get; set; }
        public int Numero { get; set; }
        public int CodigoBarras { get; set; }
        public Associado Associado { get; set; }
    }
}
