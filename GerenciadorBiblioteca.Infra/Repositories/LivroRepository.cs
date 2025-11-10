using GerenciadorBiblioteca.Domain.Entities;
using GerenciadorBiblioteca.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorBiblioteca.Infra.Repositories;

public class LivroRepository : ILivroRepository
{
    private readonly BibliotecaDbContext _context;

    public LivroRepository(BibliotecaDbContext context)
    {
        _context = context;
    }

    public async Task AdicionarAsync(Livro livro)
    {
        await _context.Livros.AddAsync(livro);
        await _context.SaveChangesAsync();
    }

    public async Task<Livro?> ObterPorIdAsync(Guid id)
    {
        return await _context.Livros.FindAsync(id);
    }

    public async Task<IEnumerable<Livro>> ListarTodosAsync()
    {
        return await _context.Livros.ToListAsync();
    }

    public async Task<bool> RemoverAsync(Guid id)
    {
        var livro = await _context.Livros.FindAsync(id);
        if (livro == null) return false;

        _context.Livros.Remove(livro);
        await _context.SaveChangesAsync();
        return true;
    }

}
