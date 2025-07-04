using GerenciadorBiblioteca.Domain.Entities;
using GerenciadorBiblioteca.Domain.Interfaces;

namespace GerenciadorBiblioteca.Infra.Repositories
{
    public class LivroRepository : ILivroRepository
    {
        private static readonly List<Livro> _livros = new();

        public void Adicionar(Livro livro)
        {
            _livros.Add(livro);
        }

        public Livro? ObterPorId(Guid id)
        {
            return _livros.FirstOrDefault(l => l.Id == id);
        }

        public IEnumerable<Livro?> ListarTodos()
        {
            return _livros;
        }

        public bool Remover(Guid id)
        {
            var livro = ObterPorId(id);
            if (livro == null) return false;

            _livros.Remove(livro);
            return true;
        }

    }
}
