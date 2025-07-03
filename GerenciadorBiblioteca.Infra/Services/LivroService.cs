using GerenciadorBiblioteca.Domain.Entities;
using GerenciadorBiblioteca.Domain.Interfaces;
using GerenciadorBiblioteca.Infra.Validators;

namespace GerenciadorBiblioteca.Infra.Services
{
    public class LivroService : ILivroService
    {
        private readonly ILivroRepository _livroRepository;

        public LivroService(ILivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }

        public void Cadastrar(Livro livro)
        {
            Validar(livro);
            _livroRepository.Adicionar(livro);
        }

        public bool Validar(Livro livro)
        {
            ValidadorObrigatorio.ValidarTexto(livro.Titulo, nameof(livro.Titulo));
            ValidadorObrigatorio.ValidarTexto(livro.Autor, nameof(livro.Autor));
            ValidadorObrigatorio.ValidarTexto(livro.Isbn, nameof(livro.Isbn));
            ValidadorObrigatorio.ValidarAno(livro.AnoPublicacao);

            return true;
        }

        public IEnumerable<Livro> ListarTodos()
        {
            return _livroRepository.ListarTodos();
        }

        public Livro? ObterPorId(Guid id)
        {
            return _livroRepository.ObterPorId(id);
        }

        public bool Remover(Guid id)
        {
            return _livroRepository.Remover(id);
        }
    }
}
