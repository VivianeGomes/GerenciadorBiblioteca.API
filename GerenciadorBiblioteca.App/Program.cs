using GerenciadorBiblioteca.Domain.Interfaces;
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
            MenuLivros(livroService);
            break;
        case "2":
            MenuUsuarios(usuarioService);
            break;
        case "3":
            MenuEmprestimos(emprestimoService);
            break;
        case "0":
            continuar = false;
            Console.WriteLine("\nAté logo, viajante das bibliotecas! ✨");
            break;
        default:
            Console.WriteLine("\nOpção inválida. Pressione qualquer tecla para tentar novamente.");
            break;
    }
}

void MenuEmprestimos(EmprestimoService emprestimoService)
{
    throw new NotImplementedException();
}

void MenuUsuarios(UsuarioService usuarioService)
{
    throw new NotImplementedException();
}

static void MenuLivros(LivroService livroService)
{
    bool voltar = false;

    while (!voltar)
    {
        Console.Clear();
        Console.WriteLine("=== 📚 Gerenciamento de Livros ===\n");
        Console.WriteLine("1. Cadastrar Livro");
        Console.WriteLine("2. Listar Todos os Livros");
        Console.WriteLine("3. Buscar Livro por ID");
        Console.WriteLine("4. Remover Livro");
        Console.WriteLine("0. Voltar ao menu principal");
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
                voltar = true;
                break;
            default:
                Console.WriteLine("Opção inválida. Pressione qualquer tecla para continuar...");
                Console.ReadKey();
                break;
        }
    }
}
