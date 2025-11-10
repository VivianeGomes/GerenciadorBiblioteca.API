namespace GerenciadorBiblioteca.Api.DTOs.Emprestimo
{
    public class DevolucaoDto
    {
        public Guid EmprestimoId { get; set; }
        public DateTime DataDevolucao { get; set; }
    }
}
