using GerenciadorBiblioteca.Infra.Services;

namespace GerenciadorBiblioteca.App.Menus
{
    public class MenuEmprestimo
    {
        public static void Exibir(EmprestimoService emprestimoService)
        {
            bool continuar = true;

            while (continuar)
            {
                Console.Clear();
                Console.WriteLine("=== 🔁 Gerenciamento de Empréstimos ===\n");
                Console.WriteLine("1. Registrar Novo Empréstimo");
                Console.WriteLine("2. Listar Todos os Empréstimos");
                Console.WriteLine("0. Voltar ao menu principal");
                Console.Write("\nEscolha uma opção: ");

                var opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        RegistrarEmprestimo(emprestimoService);
                        break;
                    case "2":
                        ListarEmprestimos(emprestimoService);
                        break;
                    case "0":
                        continuar = false;
                        break;
                    default:
                        Console.WriteLine("\nOpção inválida. Pressione qualquer tecla para continuar...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private static void RegistrarEmprestimo(EmprestimoService emprestimoService)
        {
            Console.Clear();
            Console.WriteLine("=== 🔁 Registro de Empréstimo ===\n");

            Console.Write("ID do Usuário: ");
            var idUsuarioStr = Console.ReadLine();

            Console.Write("ID do Livro: ");
            var idLivroStr = Console.ReadLine();

            if (!Guid.TryParse(idUsuarioStr, out Guid idUsuario) || !Guid.TryParse(idLivroStr, out Guid idLivro))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n❌ IDs inválidos. Certifique-se de usar o formato correto (GUID).");
            }
            else
            {
                try
                {
                    emprestimoService.RegistrarEmprestimo(idLivro, idUsuario);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n✅ Empréstimo registrado com sucesso!");
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\n❌ Erro ao registrar empréstimo: {ex.Message}");
                }
            }

            Console.ResetColor();
            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
            Console.ReadKey();
        }

        private static void ListarEmprestimos(EmprestimoService emprestimoService)
        {
            Console.Clear();
            Console.WriteLine("=== 📖 Lista de Empréstimos Registrados ===\n");

            var emprestimos = emprestimoService.ListarTodos();

            if (!emprestimos.Any())
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("⚠️ Nenhum empréstimo foi registrado ainda.");
            }
            else
            {
                foreach (var emprestimo in emprestimos)
                {
                    Console.WriteLine($"🆔 ID do Empréstimo: {emprestimo.Id}");
                    Console.WriteLine($"👤 ID do Usuário: {emprestimo.IdUsuario}");
                    Console.WriteLine($"📘 ID do Livro: {emprestimo.IdLivro}");
                    Console.WriteLine($"📅 Data de Empréstimo: {emprestimo.DataDeEmprestimo:dd/MM/yyyy HH:mm}");
                    Console.WriteLine(new string('-', 45));
                }
            }

            Console.ResetColor();
            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
            Console.ReadKey();
        }
    }
}
