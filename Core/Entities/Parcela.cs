using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public class Parcela: BaseEntity
    {
      

        public int FinanciamentoId { get; set; }
        public string NumParcelas { get; set; }
        public decimal ValorParcela { get; set; }
        public DateTime DataPagamento { get; set; }

        public Financiamento Financiamento { get; set; }
    }
}