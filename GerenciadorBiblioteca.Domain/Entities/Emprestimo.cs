namespace GerenciadorBiblioteca.Domain.Entities
{
    public class Emprestimo
    {
        public Guid Id { get; set; }
        public Guid IdUsuario { get; set; }
        public Guid IdLivro { get; set; }
        public DateTime DataDeEmprestimo { get; set; } = DateTime.Now;

        public Emprestimo() { }

        public Emprestimo(Guid id, Guid idUsuario, Guid idLivro, DateTime dataDeEmprestimo)
        {
            Id = id;
            IdUsuario = idUsuario;
            IdLivro = idLivro;
            DataDeEmprestimo = dataDeEmprestimo;
        }
    }
}
