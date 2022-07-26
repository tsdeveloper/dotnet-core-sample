using System;

namespace Core.Entities
{
    public class Emprestimos : BaseEntity
    {
        public decimal CreditValue { get; set; }
        public decimal CreditValueFee { get; set; }
        public int CreditType { get; set; }
        public int NumInstallments { get; set; }
        public DateTime ExpDay { get; set; }
    }
}