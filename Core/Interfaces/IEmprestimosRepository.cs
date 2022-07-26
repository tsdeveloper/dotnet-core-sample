using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IEmprestimosRepository
    {
        Task<Emprestimos> GetEmprestimosByIdAsync(int id);
        Task<Emprestimos> CreateEmprestimosAsync(Emprestimos emprestimo);
    
    }
}