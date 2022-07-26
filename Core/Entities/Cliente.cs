using System.Collections.Generic;

namespace Core.Entities
{
    public class Cliente : BaseEntity
    {
        public Cliente()
        {
            ListFinanciamentos = new List<Financiamento>();
        }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string UF { get; set; }
        public string Celular { get; set; }

        public ICollection<Financiamento> ListFinanciamentos { get; set; }
    }
}