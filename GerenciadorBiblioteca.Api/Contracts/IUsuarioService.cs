using GerenciadorBiblioteca.Domain.Entities;

namespace GerenciadorBiblioteca.Api.Interfaces
{
    public interface IUsuarioService
    {
        Task CadastrarAsync(Usuario usuario);
        Task<IEnumerable<Usuario>> ListarTodosAsync();
        Task<Usuario?> ObterPorIdAsync(Guid id);
        Task<bool> RemoverAsync(Guid id);
    }
}
