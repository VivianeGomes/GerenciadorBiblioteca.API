using GerenciadorBiblioteca.App.Menus;
using GerenciadorBiblioteca.Infra.Repositories;
using GerenciadorBiblioteca.Infra.Services;
using System.Threading;

static void AnimacaoDeAbertura()
{
    string[] frames =
    {
        "",
        "              ░▒▓ S C R I P T O R I A ▓▒░              ",
        "     Biblioteca encantada... carregando magia arcana... ",
        "",
        "                ✧ ⋯⋯⋯⋯⋯⋯⋯⋯⋯⋯⋯ ⋯⋯ ⋯ ✧                ",
        "                ░▒▓ Bem-vinda, Guardiã do Conhecimento ▓▒░",
        "                ✧ ⋯⋯⋯⋯⋯⋯⋯⋯⋯⋯⋯ ⋯⋯ ⋯ ✧                "
    };

    foreach (string frame in frames)
    {
        Console.Clear();
        Console.WriteLine("\n\n");
        Console.WriteLine(frame);
        Thread.Sleep(600);
    }

    Thread.Sleep(1000);
    Console.Clear();
}
AnimacaoDeAbertura();

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
    Console.WriteLine("              . . . . ✦ Bem-vinda ao ✦ . . . .");
    Console.WriteLine("╔════════════════════════════════════════════════════╗");
    Console.WriteLine("║               ✷ Scriptoria: Menu Principal ✷      ║");
    Console.WriteLine("╠════════════════════════════════════════════════════╣");
    Console.WriteLine("║ 1. Livros                  ⋯⋯ explorar tomos       ║");
    Console.WriteLine("║ 2. Usuários                ⋯⋯ registrar guardiões  ║");
    Console.WriteLine("║ 3. Empréstimos             ⋯⋯ conduzir relíquias   ║");
    Console.WriteLine("║ 0. Sair                    ⋯⋯ desaparecer ✧        ║");
    Console.WriteLine("╚════════════════════════════════════════════════════╝");
    Console.WriteLine("             . . . . . . . . . . . . . . . . . . . ✧");
    Console.Write("\n↳ Escolha um caminho mágico: ");

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
            Console.Clear();
            Console.WriteLine("\n⟡ As portas da Scriptoria se fecham lentamente... Até breve. ⟡");
            Thread.Sleep(1500);
            break;
        default:
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n✖ Encantação inválida. Pressione qualquer tecla para tentar novamente.");
            Console.ResetColor();
            Console.ReadKey();
            break;
    }
}
