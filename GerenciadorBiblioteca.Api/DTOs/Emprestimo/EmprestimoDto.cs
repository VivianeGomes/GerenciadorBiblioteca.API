namespace GerenciadorBiblioteca.Api.DTOs.Emprestimo
{
    public class EmprestimoDto
    {
        public Guid Id { get; set; }
        public Guid UsuarioId { get; set; }
        public Guid LivroId { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime? DataDevolucao { get; set; }
    }
}
