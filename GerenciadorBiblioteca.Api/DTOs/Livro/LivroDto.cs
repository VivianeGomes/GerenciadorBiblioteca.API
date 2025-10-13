namespace GerenciadorBiblioteca.Api.DTOs.Livro
{
    public class LivroDto
    {
        public Guid Id { get; set; }
        public required string Titulo { get; set; }
        public required string Autor { get; set; }
        public int AnoPublicacao { get; set; }
        public string? Genero { get; set; }
    }
}
