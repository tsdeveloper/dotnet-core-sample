using System.Threading.Tasks;
using API.Dtos;
using API.Errors;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class EmprestimosController : BaseApiController
    {
        
        private readonly IEmprestimosService _emprestimoService;
        private readonly IMapper _mapper;

        public EmprestimosController(IEmprestimosService emprestimoService, IMapper mapper)
        {
            _emprestimoService = emprestimoService;
            _mapper = mapper;
        }

        /*[Cached(600)]
        [HttpGet]
        public async Task<ActionResult<Pagination<EmprestimoToReturnDto>>> GetEmprestimos(
            [FromQuery]EmprestimoSpecParams emprestimoParams)
        {
            var spec = new EmprestimosWithTypesAndBrandsSpecification(emprestimoParams);

            var countSpec = new EmprestimoWithFiltersForCountSpecificication(emprestimoParams);

            var totalItems = await _emprestimosRepo.CountAsync(countSpec);

            var emprestimos = await _emprestimosRepo.ListAsync(spec);

            var data = _mapper
                .Map<IReadOnlyList<Emprestimo>, IReadOnlyList<EmprestimoToReturnDto>>(emprestimos);

            return Ok(new Pagination<EmprestimoToReturnDto>(emprestimoParams.PageIndex, emprestimoParams.PageSize, totalItems, data));
        }*/

        
        [HttpPost("register")]
        public async Task<ActionResult<EmprestimoToReturnDto>> CreateEmprestimo(EmprestimoToReturnDto emprestimoDto)
        {
            var resultReponse = await _emprestimoService.CreateEmprestimoAsync(_mapper.Map<Emprestimos>(emprestimoDto));

            if (resultReponse.StatusCode != 200) return BadRequest(new ApiResponse(resultReponse.StatusCode, resultReponse.Message));

            return Ok(resultReponse);
        }
    }
}