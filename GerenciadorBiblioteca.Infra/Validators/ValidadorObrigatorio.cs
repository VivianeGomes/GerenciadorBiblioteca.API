namespace GerenciadorBiblioteca.Infra.Validators
{
    public static class ValidadorObrigatorio
    {
        public static void ValidarTexto(string valor, string nomeCampo)
        {
            if (string.IsNullOrWhiteSpace(valor))
            {
                throw new ArgumentException($"O campo '{nomeCampo}' é obrigatório.");
            }
        }

        public static void ValidarAno(int ano)
        {
            if (ano <= 0)
            {
                throw new ArgumentException("O ano de publicação deve ser maior que zero.");
            }
        }

        public static void ValidarGuid(Guid id, string nomeCampo)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException($"O campo '{nomeCampo}' deve conter um Guid válido.");
            }
        }
    }
}
