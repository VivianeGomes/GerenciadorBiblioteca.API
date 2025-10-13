namespace GerenciadorBiblioteca.Domain.Entities
{
    public class Livro
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Autor { get; set; } = string.Empty;
        public string Isbn { get; set; } = string.Empty;
        public string? Genero { get; set; } = string.Empty;
        public int AnoPublicacao { get; set; }

        public Livro() { }

        public Livro(Guid id, string titulo, string autor, string isbn, int anoPublicacao, string genero)
        {
            Id = id;
            Titulo = titulo;
            Autor = autor;
            Isbn = isbn;
            AnoPublicacao = anoPublicacao;
            Genero = genero;
        }
    }
}
