using Core.Entities;
using Core.Interfaces;

namespace Infrastructure.Services
{
    public static class ValidarParcelasPermitidaValidationContract
    {
       
        public static bool Execute(Emprestimos emprestimo)
        {
            if (emprestimo.NumInstallments > Constantes.MAXIMO_QTD_PARCELAS_EMPRESTIMO ||
                emprestimo.NumInstallments < Constantes.MINIMO_QTD_PARCELAS_EMPRESTIMO )
                return false;
            
            return true;
        }
    }
}