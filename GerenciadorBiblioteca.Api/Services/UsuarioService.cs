using GerenciadorBiblioteca.Api.Interfaces;
using GerenciadorBiblioteca.Domain.Entities;
using GerenciadorBiblioteca.Domain.Interfaces;
using GerenciadorBiblioteca.Infra.Validators;

namespace GerenciadorBiblioteca.Infra.Services;

public class UsuarioService : IUsuarioService
{
    private readonly IUsuarioRepository _usuarioRepository;

    public UsuarioService(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    public async Task CadastrarAsync(Usuario usuario)
    {
        Validar(usuario);
        await _usuarioRepository.AdicionarAsync(usuario);
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

    public async Task<IEnumerable<Usuario>> ListarTodosAsync()
    {
        return await _usuarioRepository.ListarTodosAsync();
    }

    public async Task<Usuario?> ObterPorIdAsync(Guid id)
    {
        return await _usuarioRepository.ObterPorIdAsync(id);
    }

    public async Task<bool> RemoverAsync(Guid id)
    {
        return await _usuarioRepository.RemoverAsync(id);
    }
}
