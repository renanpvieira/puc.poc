using System;

namespace puc.poc.modulo.associado.dominio.WriteModel
{
    public class Associado
    {
        public Guid UniqueId { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public int CPF { get; set; }

        public int CalculaIdade()
        {
            var idade = DateTime.Now.Year - DataNascimento.Year;
            
            if (DateTime.Now.DayOfYear < DataNascimento.DayOfYear)
                idade--;

            return idade;
        }
    }
}