using GerenciadorBiblioteca.Domain.Entities;
using GerenciadorBiblioteca.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorBiblioteca.Infra.Repositories
{
    public class EmprestimoRepository : IEmprestimoRepository
    {
        private readonly BibliotecaDbContext _context;

        public EmprestimoRepository(BibliotecaDbContext context)
        {
            _context = context;
        }

        public async Task AdicionarAsync(Emprestimo emprestimo)
        {
            await _context.Emprestimos.AddAsync(emprestimo);
            await _context.SaveChangesAsync();
        }

        public async Task<Emprestimo?> ObterPorIdAsync(Guid id)
        {
            return await _context.Emprestimos
                .Include(e => e.Livro)
                .Include(e => e.Usuario)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<IEnumerable<Emprestimo>> ListarTodosAsync()
        {
            return await _context.Emprestimos
                .Include(e => e.Livro)
                .Include(e => e.Usuario)
                .ToListAsync();
        }

        public async Task<bool> AtualizarAsync(Emprestimo emprestimoAtualizado)
        {
            var existente = await _context.Emprestimos.FindAsync(emprestimoAtualizado.Id);
            if (existente == null) return false;

            _context.Entry(existente).CurrentValues.SetValues(emprestimoAtualizado);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
