using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IEmprestimosService
    {
         
        Task<Emprestimos> GetEmprestimoByIdAsync(int id);
        Task<ResultResponse<Emprestimos>> CreateEmprestimoAsync(Emprestimos emprestimo);
         
    }
}