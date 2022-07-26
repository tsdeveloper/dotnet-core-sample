using Core.Entities;
using Core.Interfaces;
using Infrastructure.Helper;

namespace Infrastructure.Services
{
    public static class ValidarVencimentoPrazoPermitidoValidationContract
    {
       
        public static bool Execute(Emprestimos emprestimo)
        {
            if (emprestimo.ExpDay.GetTotalDaysOfDateTime() > Constantes.MAXIMO_DIAS_VENCIMENTO_EMPRESTIMO ||
                emprestimo.ExpDay.GetTotalDaysOfDateTime() < Constantes.MINIMO_DIAS_VENCIMENTO_EMPRESTIMO)
                return false;
            
            return true;
        }
    }
}