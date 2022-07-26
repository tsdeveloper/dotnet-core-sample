using Core.Entities;
using Core.Interfaces;

namespace Infrastructure.Services
{
    public static class ValidarValorPermitidoValidationContract
    {
        public static bool Execute( Emprestimos emprestimo)
        {
            if (emprestimo.CreditValue > Constantes.MAXIMO_VALOR_EMPRESTIMO)
                return false;
            
            return true;
        }
    }
}