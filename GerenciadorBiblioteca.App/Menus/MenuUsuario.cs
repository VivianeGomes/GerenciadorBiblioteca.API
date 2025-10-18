//using GerenciadorBiblioteca.Domain.Entities;
//using GerenciadorBiblioteca.Infra.Services;

//namespace GerenciadorBiblioteca.App.Menus
//{
//    public class MenuUsuario
//    {
//        public static void Exibir(UsuarioService usuarioService)
//        {
//            bool continuar = true;

//            while (continuar)
//            {
//                Console.Clear();
//                Console.WriteLine("╔════════════════════════════════════════════════════════╗");
//                Console.WriteLine("║            Gerenciamento de Usuários                   ║");
//                Console.WriteLine("╠════════════════════════════════════════════════════════╣");
//                Console.WriteLine("║ 1. Cadastrar Usuário                                   ║");
//                Console.WriteLine("║ 2. Listar Todos os Usuários                            ║");
//                Console.WriteLine("║ 3. Buscar Usuário por ID                               ║");
//                Console.WriteLine("║ 4. Remover Usuário                                     ║");
//                Console.WriteLine("║ 0. Voltar ao menu principal                            ║");
//                Console.WriteLine("╚════════════════════════════════════════════════════════╝");
//                Console.Write("\nEscolha uma opção: ");

//                var opcao = Console.ReadLine();

//                switch (opcao)
//                {
//                    case "1":
//                        CadastrarUsuario(usuarioService);
//                        break;
//                    case "2":
//                        ListarUsuarios(usuarioService);
//                        break;
//                    case "3":
//                        BuscarUsuarioPorId(usuarioService);
//                        break;
//                    case "4":
//                        RemoverUsuario(usuarioService);
//                        break;
//                    case "0":
//                        continuar = false;
//                        break;
//                    default:
//                        Console.WriteLine("\nOpção inválida. Pressione qualquer tecla para continuar...");
//                        Console.ReadKey();
//                        break;
//                }
//            }
//        }


//        private static void CadastrarUsuario(UsuarioService usuarioService)
//        {
//            Console.Clear();
//            Console.WriteLine("╔════════════════════════════════════════════════════════╗");
//            Console.WriteLine("║                 Cadastro de Usuário                   ║");
//            Console.WriteLine("╚════════════════════════════════════════════════════════╝\n");

//            Console.Write("Nome completo: ");
//            var nome = Console.ReadLine();

//            Console.Write("Email: ");
//            var email = Console.ReadLine();

//            var novoUsuario = new Usuario(
//                Guid.NewGuid(),
//                nome ?? string.Empty,
//                email ?? string.Empty
//            );

//            try
//            {
//                usuarioService.Cadastrar(novoUsuario);
//                Console.ForegroundColor = ConsoleColor.Green;
//                Console.WriteLine("\n╔════════════════════════════════════════════════════╗");
//                Console.WriteLine("║        Usuário cadastrado com sucesso!             ║");
//                Console.WriteLine("╚════════════════════════════════════════════════════╝");
//            }
//            catch (Exception ex)
//            {
//                Console.ForegroundColor = ConsoleColor.Red;
//                Console.WriteLine("\n╔════════════════════════════════════════════════════╗");
//                Console.WriteLine($"║ Erro ao cadastrar usuário: {ex.Message.PadRight(42)}║");
//                Console.WriteLine("╚════════════════════════════════════════════════════╝");
//            }

//            Console.ResetColor();
//            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
//            Console.ReadKey();
//        }


//        private static void ListarUsuarios(UsuarioService usuarioService)
//        {
//            Console.Clear();
//            Console.WriteLine("╔════════════════════════════════════════════════════════╗");
//            Console.WriteLine("║            Lista de Usuários Cadastrados              ║");
//            Console.WriteLine("╚════════════════════════════════════════════════════════╝\n");

//            var usuarios = usuarioService.ListarTodos();

//            if (!usuarios.Any())
//            {
//                Console.ForegroundColor = ConsoleColor.Yellow;
//                Console.WriteLine("╔════════════════════════════════════════════════════╗");
//                Console.WriteLine("║      Nenhum usuário cadastrado no momento.         ║");
//                Console.WriteLine("╚════════════════════════════════════════════════════╝");
//            }
//            else
//            {
//                foreach (var usuario in usuarios)
//                {
//                    Console.WriteLine($"ID    : {usuario.Id}");
//                    Console.WriteLine($"Nome  : {usuario.Nome}");
//                    Console.WriteLine($"Email : {usuario.Email}");
//                    Console.WriteLine(new string('-', 50));
//                }
//            }

//            Console.ResetColor();
//            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
//            Console.ReadKey();
//        }

//        private static void BuscarUsuarioPorId(UsuarioService usuarioService)
//        {
//            Console.Clear();
//            Console.WriteLine("╔════════════════════════════════════════════════════════╗");
//            Console.WriteLine("║               Buscar Usuário por ID                   ║");
//            Console.WriteLine("╚════════════════════════════════════════════════════════╝\n");

//            Console.Write("Digite o ID do usuário (formato GUID): ");
//            var idStr = Console.ReadLine();

//            if (!Guid.TryParse(idStr, out Guid id))
//            {
//                Console.ForegroundColor = ConsoleColor.Red;
//                Console.WriteLine("\n╔════════════════════════════════════════════════════╗");
//                Console.WriteLine("║    ID inválido. Por favor, insira um GUID válido.  ║");
//                Console.WriteLine("╚════════════════════════════════════════════════════╝");
//            }
//            else
//            {
//                var usuario = usuarioService.ObterPorId(id);

//                if (usuario is null)
//                {
//                    Console.ForegroundColor = ConsoleColor.Yellow;
//                    Console.WriteLine("\n╔════════════════════════════════════════════════════╗");
//                    Console.WriteLine("║     Nenhum usuário encontrado com esse ID.         ║");
//                    Console.WriteLine("╚════════════════════════════════════════════════════╝");
//                }
//                else
//                {
//                    Console.ForegroundColor = ConsoleColor.Cyan;
//                    Console.WriteLine("\n╔════════════════════════════════════════════════════╗");
//                    Console.WriteLine($"║ ID    : {usuario.Id.ToString().PadRight(40)}║");
//                    Console.WriteLine($"║ Nome  : {usuario.Nome.PadRight(44)}║");
//                    Console.WriteLine($"║ Email : {usuario.Email.PadRight(44)}║");
//                    Console.WriteLine("╚════════════════════════════════════════════════════╝");
//                }
//            }

//            Console.ResetColor();
//            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
//            Console.ReadKey();
//        }

//        private static void RemoverUsuario(UsuarioService usuarioService)
//        {
//            Console.Clear();
//            Console.WriteLine("╔════════════════════════════════════════════════════════╗");
//            Console.WriteLine("║                    Remover Usuário                    ║");
//            Console.WriteLine("╚════════════════════════════════════════════════════════╝\n");

//            Console.Write("Digite o ID do usuário a ser removido: ");
//            var idStr = Console.ReadLine();

//            if (!Guid.TryParse(idStr, out Guid id))
//            {
//                Console.ForegroundColor = ConsoleColor.Red;
//                Console.WriteLine("\n╔════════════════════════════════════════════════════╗");
//                Console.WriteLine("║      ID inválido. Verifique e tente novamente.     ║");
//                Console.WriteLine("╚════════════════════════════════════════════════════╝");
//            }
//            else
//            {
//                var sucesso = usuarioService.Remover(id);

//                if (sucesso)
//                {
//                    Console.ForegroundColor = ConsoleColor.Green;
//                    Console.WriteLine("\n╔════════════════════════════════════════════════════╗");
//                    Console.WriteLine("║         Usuário removido com sucesso!              ║");
//                    Console.WriteLine("╚════════════════════════════════════════════════════╝");
//                }
//                else
//                {
//                    Console.ForegroundColor = ConsoleColor.Yellow;
//                    Console.WriteLine("\n╔════════════════════════════════════════════════════╗");
//                    Console.WriteLine("║     Nenhum usuário encontrado com esse ID.         ║");
//                    Console.WriteLine("╚════════════════════════════════════════════════════╝");
//                }
//            }

//            Console.ResetColor();
//            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
//            Console.ReadKey();
//        }

//    }
//}
