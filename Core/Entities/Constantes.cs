namespace Core.Entities
{
    public class Constantes
    {
        public const decimal MAXIMO_VALOR_EMPRESTIMO = 1000000M;
        public const decimal MINIMO_VALOR_PJ_EMPRESTIMO = 15000M;
        public const int MAXIMO_QTD_PARCELAS_EMPRESTIMO = 72;
        public const int MINIMO_QTD_PARCELAS_EMPRESTIMO = 5;
        public const int MINIMO_DIAS_VENCIMENTO_EMPRESTIMO = 15;
        public const int MAXIMO_DIAS_VENCIMENTO_EMPRESTIMO = 40;
        public const decimal TAXA_CREDITO_CONSIGNADO = 0.01M;
        public const decimal TAXA_CREDITO_DIRETO = 0.02M;
        public const decimal TAXA_CREDITO_PJ = 0.05M;
        public const decimal TAXA_CREDITO_PF = 0.03M;
        public const decimal TAXA_CREDITO_IMOBILIARIO = 0.09M;
    }
}