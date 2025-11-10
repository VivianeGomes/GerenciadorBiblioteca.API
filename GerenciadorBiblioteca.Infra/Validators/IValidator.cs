namespace GerenciadorBiblioteca.Infra.Validators
{
    public interface IValidator<T>
    {
        bool IsValid(T instance, out List<string> errors);
    }
}
