using GerenciadorBiblioteca.Domain.Entities;
using GerenciadorBiblioteca.Domain.Interfaces;
using GerenciadorBiblioteca.Infra.Validators;

namespace GerenciadorBiblioteca.Infra.Services
{
    public class EmprestimoService : IEmprestimoService
    {
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
            ValidadorObrigatorio.ValidarGuid(idLivro, nameof(idLivro));
            ValidadorObrigatorio.ValidarGuid(idUsuario, nameof(idUsuario));

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

            _emprestimoRepository.Adicionar(emprestimo);
        }

        public IEnumerable<Emprestimo> ListarTodos()
        {
            return _emprestimoRepository.ListarTodos();
        }

        public Emprestimo? ObterPorId(Guid id)
        {
            return _emprestimoRepository.ObterPorId(id);
        }

        private void DefinirDataDevolucao(Guid idEmprestimo, DateTime? dataDevolucao)
        {
            ValidadorObrigatorio.ValidarGuid(idEmprestimo, nameof(idEmprestimo));

            var emprestimo = _emprestimoRepository.ObterPorId(idEmprestimo);

            if (emprestimo == null)
            {
                throw new ArgumentException($"Empréstimo com ID {idEmprestimo} não encontrado.");
            }

            emprestimo.DataDeEmprestimo = dataDevolucao ?? DateTime.Now;
            _emprestimoRepository.Atualizar(emprestimo);
        }

        public void Devolver(Guid idEmprestimo)
        {
            DefinirDataDevolucao(idEmprestimo, DateTime.Now);
        }

        public string GerarMensagemDeAtraso(Guid idEmprestimo)
        {
            ValidadorObrigatorio.ValidarGuid(idEmprestimo, nameof(idEmprestimo));

            var emprestimo = _emprestimoRepository.ObterPorId(idEmprestimo);

            if (emprestimo == null)
            {
                throw new ArgumentException($"Empréstimo com ID {idEmprestimo} não encontrado.");
            }

            var dataEmprestimo = emprestimo.DataDeEmprestimo;
            var dataLimite = dataEmprestimo.AddDays(7);
            var hoje = DateTime.Now;

            if (emprestimo.DataDevolucao is null)
            {
                return hoje > dataLimite
                    ? $"O empréstimo com ID {idEmprestimo} está atrasado. Data limite: {dataLimite.ToShortDateString()}."
                    : $"O empréstimo com ID {idEmprestimo} ainda está dentro do prazo. Data limite: {dataLimite.ToShortDateString()}.";
            }
            else
            {
                return emprestimo.DataDevolucao > dataLimite
                    ? $"O empréstimo com ID {idEmprestimo} foi devolvido atrasado. Data limite: {dataLimite.ToShortDateString()}, Data de devolução: {emprestimo.DataDevolucao.Value.ToShortDateString()}."
                    : $"O empréstimo com ID {idEmprestimo} foi devolvido dentro do prazo. Data limite: {dataLimite.ToShortDateString()}, Data de devolução: {emprestimo.DataDevolucao.Value.ToShortDateString()}.";
            }
        }
    }
}
