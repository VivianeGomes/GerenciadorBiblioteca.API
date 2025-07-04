using GerenciadorBiblioteca.Domain.Entities;
using GerenciadorBiblioteca.Domain.Interfaces;

namespace GerenciadorBiblioteca.Infra.Repositories
{
    public class EmprestimoRepository : IEmprestimoRepository
    {
        private static readonly List<Emprestimo> _emprestimos = new();

        public void Adicionar(Emprestimo emprestimo)
        {
            _emprestimos.Add(emprestimo);
        }

        public Emprestimo? ObterPorId(Guid id)
        {
            return _emprestimos.FirstOrDefault(e => e.Id == id);
        }

        public IEnumerable<Emprestimo?> ListarTodos()
        {
            return _emprestimos;
        }

        public void Atualizar(Emprestimo emprestimoAtualizado)
        {
            var index = _emprestimos.FindIndex(e => e.Id == emprestimoAtualizado.Id);

            if (index != -1)
            {
                _emprestimos[index] = emprestimoAtualizado;
            }
            else
            {
                Console.WriteLine($"Empréstimo com ID {emprestimoAtualizado.Id} não encontrado.");
            }
        }
    }
}
