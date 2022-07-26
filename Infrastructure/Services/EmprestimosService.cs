using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;

namespace Infrastructure.Services
{
    public class EmprestimosService : IEmprestimosService
    {
       
        private readonly IUnitOfWork _unitOfWork;
       
        public EmprestimosService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<Emprestimos> GetEmprestimoByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ResultResponse<Emprestimos>> CreateEmprestimoAsync(Emprestimos emprestimos)
        {
            var resultReponse = new ResultResponse<Emprestimos>();
           
            
            // check fee credit emprestimo
            CreditTypeEnum enumCreditType = (CreditTypeEnum)emprestimos.CreditType;
            
            // check dia emprestimo
            var resultValidationDias = ValidarVencimentoPrazoPermitidoValidationContract
                .Execute(emprestimos);

            if (!resultValidationDias)
            {
                resultReponse.Data = emprestimos;
                resultReponse.StatusCode = 400;
                resultReponse.Message = "A data do primeiro vencimento sempre será no mínimo 15 dias e no máximo 40 dias a partir da data atual";
                return resultReponse;
            }
                
            
            // check parcelas emprestimo
            var resultValidationParcelas = ValidarParcelasPermitidaValidationContract
                .Execute(emprestimos);
            
            if (!resultValidationParcelas)
            {
                resultReponse.Data = emprestimos;
                resultReponse.StatusCode = 400;
                resultReponse.Message = "A quantidade mínima de parcelas é de 5x e a máxima é de 72x";
                return resultReponse;
            }
            
            // check valor emprestimo
            var resultValidationValorMaximo = ValidarValorPermitidoValidationContract
                .Execute(emprestimos);
            
            if (!resultValidationValorMaximo)
            {
                resultReponse.Data = emprestimos;
                resultReponse.StatusCode = 400;
                resultReponse.Message = "O valor máximo a ser liberado para qualquer tipo de empréstimo é de R$ 1.000.000,00";
                return resultReponse;
            }
            
            // check valor Min PJ emprestimo
            if (enumCreditType == CreditTypeEnum.CreditoPJ)
            {
                var resultValidationValorMinimoPJ = ValidarValorMinimoPJPermitidoValidationContract
                    .Execute(emprestimos);
            
                if (!resultValidationValorMinimoPJ)
                {
                    resultReponse.Data = emprestimos;
                    resultReponse.StatusCode = 400;
                    resultReponse.Message = "Para o crédito de pessoa jurídica, o valor mínimo a ser liberado é de R$ 15.000,00";
                    return resultReponse;
                }
            }
                

            
           
            var returnProcess = enumCreditType switch
            {
                CreditTypeEnum.CreditoConsignado => new TaxaContrato().Execute(new CreditoConsignado(), ref emprestimos),
                CreditTypeEnum.CreditoDireto => new TaxaContrato().Execute(new CreditoDireto(), ref  emprestimos),
                CreditTypeEnum.CreditoImobiliario => new TaxaContrato().Execute(new CreditoImobiliario(), ref  emprestimos),
                CreditTypeEnum.CreditoPF => new TaxaContrato().Execute(new CreditoPF(), ref  emprestimos),
                CreditTypeEnum.CreditoPJ => new TaxaContrato().Execute(new CreditoPJ(), ref  emprestimos),
            };
            
            if (!returnProcess)
                return null;
            
            // // create emprestimo
            // _unitOfWork.Repository<Emprestimo>().Add(emprestimo);
            //
            // // save to db
            // var result = await _unitOfWork.Complete();
            //
            // if (result <= 0) return null;

            // return emprestimo
            
            resultReponse.Data = emprestimos;
            resultReponse.StatusCode = 200;
            resultReponse.Message = "Registro cadstro com sucesso!";
            return resultReponse;
        }
    }
}