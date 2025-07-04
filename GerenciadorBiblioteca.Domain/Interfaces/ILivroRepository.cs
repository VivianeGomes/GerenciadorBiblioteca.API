using GerenciadorBiblioteca.Domain.Entities;

namespace GerenciadorBiblioteca.Domain.Interfaces
{
    public interface ILivroRepository
    {
        void Adicionar(Livro livro);
        Livro? ObterPorId(Guid id);
        IEnumerable<Livro> ListarTodos();
        bool Remover(Guid id);
    }
}
