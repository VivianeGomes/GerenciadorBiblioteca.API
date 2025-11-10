namespace GerenciadorBiblioteca.Api.DTOs.Emprestimo
{
    public class CriarEmprestimoDto
    {
        public Guid UsuarioId { get; set; }
        public Guid LivroId { get; set; }
    }
}
