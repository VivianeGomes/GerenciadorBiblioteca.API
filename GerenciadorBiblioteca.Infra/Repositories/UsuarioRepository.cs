using GerenciadorBiblioteca.Domain.Entities;
using GerenciadorBiblioteca.Domain.Interfaces;

namespace GerenciadorBiblioteca.Infra.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private static readonly List<Usuario> _usuarios = new();

        public void Adicionar(Usuario usuario)
        {
            _usuarios.Add(usuario);
        }

        public Usuario? ObterPorId(Guid id)
        {
            return _usuarios.FirstOrDefault(u => u.Id == id);
        }

        public IEnumerable<Usuario> ListarTodos()
        {
            return _usuarios;
        }

        public bool Remover(Guid id)
        {
            var usuario = ObterPorId(id);
            if (usuario == null) return false;

            _usuarios.Remove(usuario);
            return true;
        }
    }
}
