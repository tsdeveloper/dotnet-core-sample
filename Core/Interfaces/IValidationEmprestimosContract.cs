using Core.Entities;

namespace Core.Interfaces
{
    public interface IValidationEmprestimosContract
    {
  
        public void Execute(ref Emprestimos emprestimos);
    }
}