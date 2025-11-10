using GerenciadorBiblioteca.Domain.Entities;
using GerenciadorBiblioteca.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorBiblioteca.Infra.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly BibliotecaDbContext _context;

        public UsuarioRepository(BibliotecaDbContext context)
        {
            _context = context;
        }

        public async Task AdicionarAsync(Usuario usuario)
        {
            await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task<Usuario?> ObterPorIdAsync(Guid id)
        {
            return await _context.Usuarios.FindAsync(id);
        }

        public async Task<IEnumerable<Usuario>> ListarTodosAsync()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task<bool> RemoverAsync(Guid id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null) return false;

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
