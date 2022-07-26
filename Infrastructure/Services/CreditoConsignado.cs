using Core.Entities;
using Core.Interfaces;

namespace Infrastructure.Services
{
    public class CreditoConsignado : IValidationEmprestimosContract
    {
      

        public void Execute(ref Emprestimos emprestimo)
        {
            emprestimo.CreditValue =
                (emprestimo.CreditValue * Constantes.TAXA_CREDITO_CONSIGNADO) + emprestimo.CreditValue;
            emprestimo.CreditValueFee = (emprestimo.CreditValue * Constantes.TAXA_CREDITO_CONSIGNADO);

        }
    }
}