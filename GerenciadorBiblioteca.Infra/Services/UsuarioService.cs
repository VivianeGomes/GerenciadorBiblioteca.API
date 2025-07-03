using GerenciadorBiblioteca.Domain.Entities;
using GerenciadorBiblioteca.Domain.Interfaces;
using GerenciadorBiblioteca.Infra.Validators;

namespace GerenciadorBiblioteca.Infra.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public void Cadastrar(Usuario usuario)
        {
            Validar(usuario);
            _usuarioRepository.Adicionar(usuario);
        }

        public bool Validar(Usuario usuario)
        {
            ValidadorObrigatorio.ValidarTexto(usuario.Nome, nameof(usuario.Nome));
            ValidadorObrigatorio.ValidarTexto(usuario.Email, nameof(usuario.Email));

            return true;
        }

        public IEnumerable<Usuario> ListarTodos()
        {
            return _usuarioRepository.ListarTodos();
        }

        public Usuario? ObterPorId(Guid id)
        {
            return _usuarioRepository.ObterPorId(id);
        }

        public bool Remover(Guid id)
        {
            return _usuarioRepository.Remover(id);
        }
    }
}
