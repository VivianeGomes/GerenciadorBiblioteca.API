using GerenciadorBiblioteca.Api.DTOs.Livro;

namespace GerenciadorBiblioteca.Api.Interfaces;

public interface ILivroService
{
    Task<LivroDto> CadastrarAsync(CriarLivroDto dto);
    Task<IEnumerable<LivroDto>> ListarTodosAsync();
    Task<LivroDto?> ObterPorIdAsync(Guid id);
    Task<bool> RemoverAsync(Guid id);
}
