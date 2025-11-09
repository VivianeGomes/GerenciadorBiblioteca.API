using Microsoft.EntityFrameworkCore;

namespace GerenciadorBiblioteca.Infra;

public class BibliotecaDbContext : DbContext
{
    public BibliotecaDbContext(DbContextOptions<BibliotecaDbContext> options)
    : base(options)
    {
    }

    public DbSet<Domain.Entities.Livro> Livros { get; set; }
    public DbSet<Domain.Entities.Usuario> Usuarios { get; set; }
    public DbSet<Domain.Entities.Emprestimo> Emprestimos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Domain.Entities.Livro>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Titulo).IsRequired().HasMaxLength(200);
            entity.Property(e => e.Autor).IsRequired().HasMaxLength(100);
            entity.Property(e => e.AnoPublicacao).IsRequired();
        });
        modelBuilder.Entity<Domain.Entities.Usuario>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Nome).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Email).IsRequired().HasMaxLength(100);
        });
        modelBuilder.Entity<Domain.Entities.Emprestimo>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.DataDeEmprestimo).IsRequired();
            entity.Property(e => e.DataDevolucao).IsRequired(false);
            entity.HasOne<Domain.Entities.Livro>()
                  .WithMany()
                  .HasForeignKey(e => e.IdLivro)
                  .OnDelete(DeleteBehavior.Cascade);
            entity.HasOne<Domain.Entities.Usuario>()
                  .WithMany()
                  .HasForeignKey(e => e.IdUsuario)
                  .OnDelete(DeleteBehavior.Cascade);
        });
    }
}