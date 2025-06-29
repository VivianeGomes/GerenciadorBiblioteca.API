using GerenciadorBiblioteca.Domain.Entities;

namespace GerenciadorBiblioteca.Domain.Interfaces
{
    public interface IUsuarioService
    {
        void Cadastrar(Usuario usuario);
        IEnumerable<Usuario> ListarTodos();
        Usuario? ObterPorId(Guid id);
        bool Remover(Guid id);
    }
}
