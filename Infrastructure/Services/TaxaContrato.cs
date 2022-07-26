using Core.Entities;
using Core.Interfaces;

namespace Infrastructure.Services
{
    public class TaxaContrato
    {
       
        public bool Execute(IValidationEmprestimosContract contract, ref Emprestimos emprestimo)
        {
            contract.Execute(ref emprestimo);
            return true;
        }
    }
}