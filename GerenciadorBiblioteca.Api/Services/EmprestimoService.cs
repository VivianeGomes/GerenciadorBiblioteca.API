using GerenciadorBiblioteca.Api.Interfaces;
using GerenciadorBiblioteca.Domain.Entities;
using GerenciadorBiblioteca.Domain.Interfaces;
using GerenciadorBiblioteca.Infra.Validators;

namespace GerenciadorBiblioteca.Infra.Services;

public class EmprestimoService : IEmprestimoService
{
    private const int PRAZO_PADRAO_EM_DIAS = 7;
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly ILivroRepository _livroRepository;
    private readonly IEmprestimoRepository _emprestimoRepository;

    public EmprestimoService(
        IUsuarioRepository usuarioRepository,
        ILivroRepository livroRepository,
        IEmprestimoRepository emprestimoRepository)
    {
        _usuarioRepository = usuarioRepository;
        _livroRepository = livroRepository;
        _emprestimoRepository = emprestimoRepository;
    }

    public async Task RegistrarEmprestimoAsync(Guid idLivro, Guid idUsuario)
    {
        var livro = await _livroRepository.ObterPorIdAsync(idLivro);
        var usuario = await _usuarioRepository.ObterPorIdAsync(idUsuario);

        if (livro == null)
            throw new ArgumentException($"Livro com ID {idLivro} não encontrado.");

        if (usuario == null)
            throw new ArgumentException($"Usuário com ID {idUsuario} não encontrado.");

        var emprestimo = new Emprestimo
        (
            Guid.NewGuid(),
            idLivro,
            livro,
            idUsuario,
            usuario,
            DateTime.Now,
            DateTime.Now.AddDays(PRAZO_PADRAO_EM_DIAS)
        );

        ValidarEmprestimo(emprestimo);

        await _emprestimoRepository.AdicionarAsync(emprestimo);
    }

    private void ValidarEmprestimo(Emprestimo emprestimo)
    {
        var validator = new EmprestimoValidator();

        if (!validator.IsValid(emprestimo, out var errors))
        {
            throw new ArgumentException(string.Join("; ", errors));
        }
    }

    public async Task<IEnumerable<Emprestimo>> ListarTodosAsync()
    {
        return await _emprestimoRepository.ListarTodosAsync();
    }

    public async Task<Emprestimo?> ObterPorIdAsync(Guid id)
    {
        return await _emprestimoRepository.ObterPorIdAsync(id);
    }

    public async Task DefinirDataDevolucaoAsync(Guid idEmprestimo, DateTime? dataDevolucao)
    {
        var emprestimo = await ValidarEmprestimoExistenteAsync(idEmprestimo);

        emprestimo.DataDevolucao = dataDevolucao ?? DateTime.Now;
        await _emprestimoRepository.AtualizarAsync(emprestimo);
    }

    public async Task DevolverAsync(Guid idEmprestimo)
    {
        await DefinirDataDevolucaoAsync(idEmprestimo, DateTime.Now);
    }

    public async Task<string> GerarMensagemDeAtrasoAsync(Guid idEmprestimo)
    {
        var emprestimo = await ValidarEmprestimoExistenteAsync(idEmprestimo);

        var dataEmprestimo = emprestimo.DataDeEmprestimo;
        var dataLimite = dataEmprestimo.AddDays(PRAZO_PADRAO_EM_DIAS);
        var hoje = DateTime.Now;

        if (emprestimo.DataDevolucao is null)
        {
            return hoje > dataLimite
                ? $"O empréstimo com ID {idEmprestimo} está atrasado. Data limite: {dataLimite:dd/MM/yyyy}."
                : $"O empréstimo com ID {idEmprestimo} ainda está dentro do prazo. Data limite: {dataLimite:dd/MM/yyyy}.";
        }
        else
        {
            return emprestimo.DataDevolucao > dataLimite
                ? $"O empréstimo com ID {idEmprestimo} foi devolvido atrasado. Data limite: {dataLimite:dd/MM/yyyy}, Data de devolução: {emprestimo.DataDevolucao:dd/MM/yyyy}."
                : $"O empréstimo com ID {idEmprestimo} foi devolvido dentro do prazo. Data limite: {dataLimite:dd/MM/yyyy}, Data de devolução: {emprestimo.DataDevolucao:dd/MM/yyyy}.";
        }
    }

    private async Task<Emprestimo> ValidarEmprestimoExistenteAsync(Guid idEmprestimo)
    {
        var emprestimo = await _emprestimoRepository.ObterPorIdAsync(idEmprestimo);

        if (emprestimo == null)
            throw new ArgumentException($"Empréstimo com ID {idEmprestimo} não encontrado.");

        return emprestimo;
    }
}
