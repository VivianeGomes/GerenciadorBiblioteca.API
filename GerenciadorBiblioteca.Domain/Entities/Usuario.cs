namespace GerenciadorBiblioteca.Domain.Entities
{
    public class Usuario
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public Usuario() { }

        public Usuario(Guid id, string nome, string email)
        {
            Id = id;
            Nome = nome;
            Email = email;
        }
    }
}
