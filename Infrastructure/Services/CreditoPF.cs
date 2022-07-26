using Core.Entities;
using Core.Interfaces;

namespace Infrastructure.Services
{
    public class CreditoPF : IValidationEmprestimosContract
    {
        public void Execute(ref Emprestimos emprestimo)
        {
            emprestimo.CreditValue =
                (emprestimo.CreditValue * Constantes.TAXA_CREDITO_PF) + emprestimo.CreditValue;
            emprestimo.CreditValueFee = (emprestimo.CreditValue * Constantes.TAXA_CREDITO_PF);

        }
    }
}