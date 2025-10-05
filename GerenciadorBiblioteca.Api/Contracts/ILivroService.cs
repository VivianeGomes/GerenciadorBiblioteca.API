using GerenciadorBiblioteca.Api.DTOs.Livro;
using GerenciadorBiblioteca.Domain.Entities;

namespace GerenciadorBiblioteca.Domain.Interfaces
{
    public interface ILivroService
    {
        LivroDto Cadastrar(CriarLivroDto dto);
        IEnumerable<Livro> ListarTodos();
        Livro? ObterPorId(Guid id);
        bool Remover(Guid id);
    }
}
