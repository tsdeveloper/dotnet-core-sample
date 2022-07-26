using Core.Entities;
using Core.Interfaces;
using Infrastructure.Helper;

namespace Infrastructure.Services
{
    public static class ValidarValorMinimoPJPermitidoValidationContract
    {
       
        public static bool Execute(Emprestimos emprestimo)
        {
            if (emprestimo.CreditValue < Constantes.MINIMO_VALOR_PJ_EMPRESTIMO)
                return false;
            
            return true;
        }
    }
}