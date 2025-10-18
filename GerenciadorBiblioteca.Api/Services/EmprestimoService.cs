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

    public void RegistrarEmprestimo(Guid idLivro, Guid idUsuario)
    {
        var livro = _livroRepository.ObterPorId(idLivro);
        var usuario = _usuarioRepository.ObterPorId(idUsuario);

        if (livro == null)
        {
            throw new ArgumentException($"Livro com ID {idLivro} não encontrado.");
        }
        if (usuario == null)
        {
            throw new ArgumentException($"Usuário com ID {idUsuario} não encontrado.");
        }

        var emprestimo = new Emprestimo
        (
            Guid.NewGuid(),
            idLivro,
            idUsuario,
            DateTime.Now
        );

        ValidarEmprestimo(emprestimo);

        _emprestimoRepository.Adicionar(emprestimo);
    }

    private void ValidarEmprestimo(Emprestimo emprestimo)
    {
        var validator = new EmprestimoValidator();

        if (!validator.IsValid(emprestimo, out var errors))
        {
            throw new ArgumentException(string.Join("; ", errors));
        }
    }

    public IEnumerable<Emprestimo> ListarTodos()
    {
        return _emprestimoRepository.ListarTodos();
    }

    public Emprestimo? ObterPorId(Guid id)
    {
        return _emprestimoRepository.ObterPorId(id);
    }

    public void DefinirDataDevolucao(Guid idEmprestimo, DateTime? dataDevolucao)
    {
        var emprestimo = ValidarEmprestimoExistente(idEmprestimo);

        emprestimo.DataDevolucao = dataDevolucao ?? DateTime.Now;
        _emprestimoRepository.Atualizar(emprestimo);
    }

    public void Devolver(Guid idEmprestimo)
    {
        DefinirDataDevolucao(idEmprestimo, DateTime.Now);
    }

    public string GerarMensagemDeAtraso(Guid idEmprestimo)
    {
        var emprestimo = ValidarEmprestimoExistente(idEmprestimo);

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

    private Emprestimo ValidarEmprestimoExistente(Guid idEmprestimo)
    {
        var emprestimo = _emprestimoRepository.ObterPorId(idEmprestimo);

        if (emprestimo == null)
        {
            throw new ArgumentException($"Empréstimo com ID {idEmprestimo} não encontrado.");
        }

        return emprestimo;
    }


}
