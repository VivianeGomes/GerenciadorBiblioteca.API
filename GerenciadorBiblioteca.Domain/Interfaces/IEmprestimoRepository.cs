using GerenciadorBiblioteca.Domain.Entities;

namespace GerenciadorBiblioteca.Domain.Interfaces
{
    public interface IEmprestimoRepository
    {
        void Adicionar(Emprestimo emprestimo);
        Emprestimo? ObterPorId(Guid id);
        IEnumerable<Emprestimo> ListarTodos();
        bool Atualizar(Emprestimo emprestimo);
    }
}
