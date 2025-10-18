using GerenciadorBiblioteca.Domain.Entities;

namespace GerenciadorBiblioteca.Api.Interfaces;

public interface IEmprestimoService
{
    void RegistrarEmprestimo(Guid idLivro, Guid idUsuario);
    void DefinirDataDevolucao(Guid idEmprestimo, DateTime? dataDevolucao);
    void Devolver(Guid idEmprestimo);
    string GerarMensagemDeAtraso(Guid idEmprestimo);
    IEnumerable<Emprestimo> ListarTodos();
    Emprestimo? ObterPorId(Guid id);
}
