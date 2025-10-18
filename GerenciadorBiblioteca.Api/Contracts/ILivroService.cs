using GerenciadorBiblioteca.Api.DTOs.Livro;

namespace GerenciadorBiblioteca.Api.Interfaces;

public interface ILivroService
{
    LivroDto Cadastrar(CriarLivroDto dto);
    IEnumerable<LivroDto> ListarTodos();
    LivroDto? ObterPorId(Guid id);
    bool Remover(Guid id);
}
