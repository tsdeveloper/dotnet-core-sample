using Core.Entities;

namespace Core.Specifications
{
    public class EmprestimosByIdSpecification : BaseSpecification<Emprestimos>
    {
        public EmprestimosByIdSpecification(int id) 
            : base(o => o.Id == id)
        {
        }
    }
}