using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public class Financiamento : BaseEntity
    {
        public Financiamento()
        {
            ListParcelas = new List<Parcela>();
        }
        public int ClienteId { get; set; }
        public string Cpf { get; set; }
        public string Tipo { get; set; }
        public decimal ValorTotal { get; set; }
        public DateTime DataUltimoVencimento { get; set; }
        public ICollection<Parcela> ListParcelas { get; set; }
        
        public Cliente Cliente { get; set; }
      
    }
}