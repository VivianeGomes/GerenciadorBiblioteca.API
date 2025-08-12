namespace GerenciadorBiblioteca.Api.DTOs.Livro
{
    public class CriarLivroDto
    {
        public required string Titulo { get; set; }
        public required string Autor { get; set; }
        public int AnoPublicacao { get; set; }
        public string? Genero { get; set; }
    }
}
