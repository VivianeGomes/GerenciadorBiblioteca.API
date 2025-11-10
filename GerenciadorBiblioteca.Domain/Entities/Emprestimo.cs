namespace GerenciadorBiblioteca.Domain.Entities;

public class Emprestimo
{
    public Guid Id { get; set; }

    public Guid IdLivro { get; set; }
    public Livro Livro { get; set; } = null!;

    public Guid IdUsuario { get; set; }
    public Usuario Usuario { get; set; } = null!;

    public DateTime DataDeEmprestimo { get; set; }
    public DateTime? DataDevolucao { get; set; }

    public Emprestimo() { }

    public Emprestimo(Guid id, Guid idLivro, Livro livro, Guid idUsuario, Usuario usuario, DateTime dataDeEmprestimo, DateTime? dataDevolucao)
    {
        Id = id;
        IdLivro = idLivro;
        Livro = livro;
        IdUsuario = idUsuario;
        Usuario = usuario;
        DataDeEmprestimo = dataDeEmprestimo;
        DataDevolucao = dataDevolucao;
    }
}
