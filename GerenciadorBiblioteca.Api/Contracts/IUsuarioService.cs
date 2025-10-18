using GerenciadorBiblioteca.Domain.Entities;

namespace GerenciadorBiblioteca.Api.Interfaces
{
    public interface IUsuarioService
    {
        void Cadastrar(Usuario usuario);
        IEnumerable<Usuario> ListarTodos();
        Usuario? ObterPorId(Guid id);
        bool Remover(Guid id);
    }
}
