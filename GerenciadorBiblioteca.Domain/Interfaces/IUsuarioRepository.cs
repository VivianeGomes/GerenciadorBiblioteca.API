using GerenciadorBiblioteca.Domain.Entities;

namespace GerenciadorBiblioteca.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        void Adicionar(Usuario usuario);
        Usuario? ObterPorId(Guid id);
        IEnumerable<Usuario> ListarTodos();
        bool Remover(Guid id);
    }
}
