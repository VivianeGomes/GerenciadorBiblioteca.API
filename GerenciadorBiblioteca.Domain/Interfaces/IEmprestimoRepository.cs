using GerenciadorBiblioteca.Domain.Entities;

namespace GerenciadorBiblioteca.Domain.Interfaces
{
    public interface IEmprestimoRepository
    {
        Task AdicionarAsync(Emprestimo emprestimo);
        Task<Emprestimo?> ObterPorIdAsync(Guid id);
        Task<IEnumerable<Emprestimo>> ListarTodosAsync();
        Task<bool> AtualizarAsync(Emprestimo emprestimo);
    }
}
