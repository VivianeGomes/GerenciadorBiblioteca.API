using GerenciadorBiblioteca.Domain.Entities;

namespace GerenciadorBiblioteca.Infra.Validators;

public class LivroValidator : IValidator<Livro>
{
    public bool IsValid(Livro livro, out List<string> errors)
    {
        errors = new List<string>();

        if (string.IsNullOrWhiteSpace(livro.Titulo))
            errors.Add("Título é obrigatório.");

        if (string.IsNullOrWhiteSpace(livro.Autor))
            errors.Add("Autor é obrigatório.");

        if (string.IsNullOrWhiteSpace(livro.Isbn))
            errors.Add("ISBN é obrigatório.");
        else if (!IsValidIsbn(livro.Isbn))
            errors.Add("ISBN inválido (aceita ISBN-10 ou ISBN-13).");

        if (livro.AnoPublicacao <= 0)
            errors.Add("Ano de publicação deve ser maior que zero.");
        else if (livro.AnoPublicacao > DateTime.Now.Year)
            errors.Add("Ano de publicação não pode ser no futuro.");

        return errors.Count == 0;
    }

    private bool IsValidIsbn(string isbn)
    {
        var digits = new string(isbn.Where(char.IsDigit).ToArray());
        return digits.Length == 10 || digits.Length == 13;
    }
}


public class UsuarioValidator : IValidator<Usuario>
{
    public bool IsValid(Usuario usuario, out List<string> errors)
    {
        errors = new List<string>();

        if (string.IsNullOrWhiteSpace(usuario.Nome))
            errors.Add("Nome é obrigatório.");

        if (string.IsNullOrWhiteSpace(usuario.Email))
            errors.Add("Email é obrigatório.");
        else if (!IsValidEmail(usuario.Email))
            errors.Add("Email inválido.");

        return errors.Count == 0;
    }

    private bool IsValidEmail(string email)
    {
        try
        {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == email;
        }
        catch { return false; }
    }
}

public class EmprestimoValidator : IValidator<Emprestimo>
{
    public bool IsValid(Emprestimo emprestimo, out List<string> errors)
    {
        errors = new List<string>();

        if (emprestimo.IdUsuario == Guid.Empty)
            errors.Add("UsuárioId é obrigatório.");

        if (emprestimo.IdLivro == Guid.Empty)
            errors.Add("LivroId é obrigatório.");

        if (emprestimo.DataDeEmprestimo == default)
            errors.Add("Data de empréstimo é obrigatória.");

        return errors.Count == 0;
    }
}


