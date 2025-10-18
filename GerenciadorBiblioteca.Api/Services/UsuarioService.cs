using GerenciadorBiblioteca.Api.Interfaces;
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
            var validator = new UsuarioValidator();

            if (!validator.IsValid(usuario, out var errors))
            {
                throw new ArgumentException(string.Join("; ", errors));
            }

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
