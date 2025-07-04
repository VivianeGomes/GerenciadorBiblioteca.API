using GerenciadorBiblioteca.App.Menus;
using GerenciadorBiblioteca.Infra.Repositories;
using GerenciadorBiblioteca.Infra.Services;

var livroService = new LivroService(new LivroRepository());
var usuarioService = new UsuarioService(new UsuarioRepository());
var emprestimoService = new EmprestimoService(
    new UsuarioRepository(),
    new LivroRepository(),
    new EmprestimoRepository());

bool continuar = true;

while (continuar)
{
    Console.Clear();
    Console.WriteLine("=== Scriptoria – Gerenciador de Biblioteca ===\n");
    Console.WriteLine("1. 📚 Livros");
    Console.WriteLine("2. 👤 Usuários");
    Console.WriteLine("3. 📖 Empréstimos");
    Console.WriteLine("0. ❌ Sair");
    Console.Write("\nEscolha uma opção: ");

    var opcao = Console.ReadLine();

    switch (opcao)
    {
        case "1":
            MenuLivro.Exibir(livroService);
            break;
        case "2":
            MenuUsuario.Exibir(usuarioService);
            break;
        case "3":
            MenuEmprestimo.Exibir(emprestimoService);
            break;
        case "0":
            continuar = false;
            Console.WriteLine("\nAté logo, viajante das bibliotecas! ✨");
            break;
        default:
            Console.WriteLine("\nOpção inválida. Pressione qualquer tecla para tentar novamente.");
            Console.ReadKey();
            break;
    }
}
