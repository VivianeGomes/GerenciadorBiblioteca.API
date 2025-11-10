using GerenciadorBiblioteca.Domain.Entities;

namespace GerenciadorBiblioteca.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        Task AdicionarAsync(Usuario usuario);
        Task<Usuario?> ObterPorIdAsync(Guid id);
        Task<IEnumerable<Usuario>> ListarTodosAsync();
        Task<bool> RemoverAsync(Guid id);
    }
}
