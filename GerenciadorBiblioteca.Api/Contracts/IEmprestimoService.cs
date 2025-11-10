using GerenciadorBiblioteca.Domain.Entities;

namespace GerenciadorBiblioteca.Api.Interfaces;

public interface IEmprestimoService
{
    Task RegistrarEmprestimoAsync(Guid idLivro, Guid idUsuario);
    Task DefinirDataDevolucaoAsync(Guid idEmprestimo, DateTime? dataDevolucao);
    Task DevolverAsync(Guid idEmprestimo);
    Task<string> GerarMensagemDeAtrasoAsync(Guid idEmprestimo);
    Task<IEnumerable<Emprestimo>> ListarTodosAsync();
    Task<Emprestimo?> ObterPorIdAsync(Guid id);
}
