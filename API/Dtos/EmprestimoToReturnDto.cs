using System;

namespace API.Dtos
{
    public class EmprestimoToReturnDto
    {
        public decimal CreditValue { get; set; }
        public int CreditType { get; set; }
        public int NumInstallments { get; set; }
        public string ExpDay { get; set; }
    }
}