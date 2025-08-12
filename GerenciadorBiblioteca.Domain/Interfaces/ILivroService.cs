using GerenciadorBiblioteca.Domain.Entities;

namespace GerenciadorBiblioteca.Domain.Interfaces
{
    public interface ILivroService
    {
        void Cadastrar(Livro livro);
        IEnumerable<Livro> ListarTodos();
        Livro? ObterPorId(Guid id);
        bool Remover(Guid id);
    }
}
