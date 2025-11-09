using GerenciadorBiblioteca.Domain.Entities;

namespace GerenciadorBiblioteca.Domain.Interfaces
{
    public interface ILivroRepository
    {
        Task AdicionarAsync(Livro livro);
        Task<Livro?> ObterPorIdAsync(Guid id);
        Task<IEnumerable<Livro>> ListarTodosAsync();
        Task<bool> RemoverAsync(Guid id);
    }
}
