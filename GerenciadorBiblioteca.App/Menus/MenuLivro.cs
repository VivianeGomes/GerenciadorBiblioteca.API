using GerenciadorBiblioteca.Domain.Entities;
using GerenciadorBiblioteca.Infra.Services;

namespace GerenciadorBiblioteca.App.Menus
{
    public class MenuLivro
    {
        public static void Exibir(LivroService livroService)
        {
            bool continuar = true;

            while (continuar)
            {
                Console.Clear();
                Console.WriteLine("=== 📚 Gerenciamento de Livros ===\n");
                Console.WriteLine("1. Cadastrar Livro");
                Console.WriteLine("2. Listar Todos os Livros");
                Console.WriteLine("3. Buscar Livro por ID");
                Console.WriteLine("4. Remover Livro");
                Console.WriteLine("0. Voltar ao Menu Principal");
                Console.Write("\nEscolha uma opção: ");

                var opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        CadastrarLivro(livroService);
                        break;
                    case "2":
                        ListarLivros(livroService);
                        break;
                    case "3":
                        BuscarLivroPorId(livroService);
                        break;
                    case "4":
                        RemoverLivro(livroService);
                        break;
                    case "0":
                        continuar = false;
                        break;
                    default:
                        Console.WriteLine("\nOpção inválida. Pressione qualquer tecla para tentar novamente.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private static void CadastrarLivro(LivroService livroservice)
        {
            Console.Clear();
            Console.WriteLine("=== ✍️ Cadastro de Livro ===\n");

            Console.WriteLine("Digite o título do livro:");
            var titulo = Console.ReadLine();

            Console.WriteLine("Digite o autor do livro:");
            var autor = Console.ReadLine();

            Console.WriteLine("Digite o ISBN do livro:");
            var isbn = Console.ReadLine();

            Console.WriteLine("Digite o ano de publicação do livro:");
            var anoString = Console.ReadLine();

            int.TryParse(anoString, out int anoPublicacao);

            var novoLivro = new Livro(Guid.NewGuid(), titulo ?? "", autor ?? "", isbn ?? "", anoPublicacao);

            try
            {
                livroservice.Cadastrar(novoLivro);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nLivro cadastrado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nErro ao cadastrar livro: {ex.Message}");
            }
            finally
            {
                Console.ResetColor();
                Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
                Console.ReadKey();
            }

        }

        private static void ListarLivros(LivroService livroService)
        {
            Console.Clear();
            Console.WriteLine("=== 📚 Lista de Livros Cadastrados ===\n");

            var livros = livroService.ListarTodos();

            if (!livros.Any())
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("⚠️ Nenhum livro cadastrado ainda.");
                Console.ResetColor();
            }
            else
            {
                foreach (var livro in livros)
                {
                    Console.WriteLine($"🆔 ID: {livro.Id}");
                    Console.WriteLine($"📖 Título: {livro.Titulo}");
                    Console.WriteLine($"✍️ Autor: {livro.Autor}");
                    Console.WriteLine($"📚 ISBN: {livro.Isbn}");
                    Console.WriteLine($"📅 Ano de Publicação: {livro.AnoPublicacao}");
                    Console.WriteLine(new string('=', 40));
                }
            }

            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
            Console.ReadKey();
        }

        private static void BuscarLivroPorId(LivroService livroService) 
        {
            Console.Clear();
            Console.WriteLine("=== 🔍 Buscar Livro por ID ===\n");

            Console.Write("Digite o ID do livro (ou cole um GUID): ");
            var idString = Console.ReadLine();

            if (!Guid.TryParse(idString, out Guid id))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n❌ ID inválido. Certifique-se de digitar um GUID válido.");
                Console.ResetColor();
            }
            else
            {
                var livro = livroService.ObterPorId(id);

                if (livro is null)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\n⚠️ Nenhum livro encontrado com esse ID.");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"\n🆔 ID: {livro.Id}");
                    Console.WriteLine($"📖 Título: {livro.Titulo}");
                    Console.WriteLine($"✍️ Autor: {livro.Autor}");
                    Console.WriteLine($"🔢 ISBN: {livro.Isbn}");
                    Console.WriteLine($"📅 Ano de Publicação: {livro.AnoPublicacao}");
                }

                Console.ResetColor();
            }

            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
            Console.ReadKey();
        }
        private static void RemoverLivro(LivroService livroService)
        {
            Console.Clear();
            Console.WriteLine("=== ❌ Remover Livro ===\n");

            Console.Write("Digite o ID do livro a ser removido: ");
            var idString = Console.ReadLine();

            if (!Guid.TryParse(idString, out Guid id))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n❌ ID inválido. Certifique-se de digitar um GUID válido.");
            }
            else
            {
                var sucesso = livroService.Remover(id);

                if (sucesso)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n✅ Livro removido com sucesso!");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\n⚠️ Nenhum livro encontrado com esse ID. Nada foi removido.");
                }
            }

            Console.ResetColor();
            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
            Console.ReadKey();
        }
    }
}
