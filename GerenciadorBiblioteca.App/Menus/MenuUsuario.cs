using GerenciadorBiblioteca.Domain.Entities;
using GerenciadorBiblioteca.Infra.Services;

namespace GerenciadorBiblioteca.App.Menus
{
    public class MenuUsuario
    {
        public static void Exibir(UsuarioService usuarioService)
        {
            bool continuar = true;

            while (continuar)
            {
                Console.Clear();
                Console.WriteLine("=== 👤 Gerenciamento de Usuários ===\n");
                Console.WriteLine("1. Cadastrar Usuário");
                Console.WriteLine("2. Listar Todos os Usuários");
                Console.WriteLine("3. Buscar Usuário por ID");
                Console.WriteLine("4. Remover Usuário");
                Console.WriteLine("0. Voltar ao menu principal");
                Console.Write("\nEscolha uma opção: ");

                var opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        CadastrarUsuario(usuarioService);
                        break;
                    case "2":
                        ListarUsuarios(usuarioService);
                        break;
                    case "3":
                        BuscarUsuarioPorId(usuarioService);
                        break;
                    case "4":
                        RemoverUsuario(usuarioService);
                        break;
                    case "0":
                        continuar = false;
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Pressione qualquer tecla para continuar...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private static void CadastrarUsuario(UsuarioService usuarioService)
        {
            Console.Clear();
            Console.WriteLine("=== ✍️ Cadastro de Usuário ===\n");

            Console.Write("Nome completo: ");
            var nome = Console.ReadLine();

            Console.Write("Email: ");
            var email = Console.ReadLine();

            var novoUsuario = new Usuario(
                Guid.NewGuid(),
                nome ?? string.Empty,
                email ?? string.Empty
            );

            try
            {
                usuarioService.Cadastrar(novoUsuario);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n✅ Usuário cadastrado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n❌ Erro ao cadastrar usuário: {ex.Message}");
            }

            Console.ResetColor();
            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
            Console.ReadKey();
        }

        private static void ListarUsuarios(UsuarioService usuarioService)
        {
            Console.Clear();
            Console.WriteLine("=== 👤 Lista de Usuários Cadastrados ===\n");

            var usuarios = usuarioService.ListarTodos();

            if (!usuarios.Any())
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("⚠️ Nenhum usuário cadastrado ainda.");
            }
            else
            {
                foreach (var usuario in usuarios)
                {
                    Console.WriteLine($"🆔 ID: {usuario.Id}");
                    Console.WriteLine($"👤 Nome: {usuario.Nome}");
                    Console.WriteLine($"📧 Email: {usuario.Email}");
                    Console.WriteLine(new string('-', 40));
                }
            }

            Console.ResetColor();
            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
            Console.ReadKey();
        }

        private static void BuscarUsuarioPorId(UsuarioService usuarioService)
        {
            Console.Clear();
            Console.WriteLine("=== 🔍 Buscar Usuário por ID ===\n");

            Console.Write("Digite o ID do usuário (formato GUID): ");
            var idStr = Console.ReadLine();

            if (!Guid.TryParse(idStr, out Guid id))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n❌ ID inválido. Por favor, insira um GUID válido.");
            }
            else
            {
                var usuario = usuarioService.ObterPorId(id);

                if (usuario is null)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\n⚠️ Nenhum usuário encontrado com esse ID.");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"\n🆔 ID: {usuario.Id}");
                    Console.WriteLine($"👤 Nome: {usuario.Nome}");
                    Console.WriteLine($"📧 Email: {usuario.Email}");
                }
            }

            Console.ResetColor();
            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
            Console.ReadKey();
        }

        private static void RemoverUsuario(UsuarioService usuarioService)
        {
            Console.Clear();
            Console.WriteLine("=== ❌ Remover Usuário ===\n");

            Console.Write("Digite o ID do usuário a ser removido: ");
            var idStr = Console.ReadLine();

            if (!Guid.TryParse(idStr, out Guid id))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n❌ ID inválido. Verifique e tente novamente.");
            }
            else
            {
                var sucesso = usuarioService.Remover(id);

                if (sucesso)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n✅ Usuário removido com sucesso!");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\n⚠️ Nenhum usuário encontrado com esse ID.");
                }
            }

            Console.ResetColor();
            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
            Console.ReadKey();
        }
    }
}
