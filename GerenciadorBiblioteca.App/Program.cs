//using GerenciadorBiblioteca.App.Menus;
//using GerenciadorBiblioteca.Infra.Repositories;
//using GerenciadorBiblioteca.Infra.Services;
//using System.Text;
//using System.Threading;

//Console.OutputEncoding = Encoding.UTF8;

//// ✦ Função auxiliar: digita letra por letra
//static void ExibirTextoComEfeito(string texto, int delay = 30)
//{
//    foreach (char c in texto)
//    {
//        Console.Write(c);
//        Thread.Sleep(delay);
//    }
//    Console.WriteLine();
//}

//// ✦ Abertura encantada com efeito de digitação
//static void AnimacaoDeAbertura()
//{
//    Console.Clear();
//    Console.WriteLine();
//    ExibirTextoComEfeito("░▒▓ S C R I P T O R I A ▓▒░", 50);
//    Thread.Sleep(500);
//    ExibirTextoComEfeito("Biblioteca encantada... despertando vestígios arcanos...", 30);
//    Thread.Sleep(600);
//    Console.WriteLine();
//    ExibirTextoComEfeito("✧⋯⋯⋯⋯⋯⋯⋯⋯⋯⋯⋯⋯⋯✧", 25);
//    ExibirTextoComEfeito("░▒▓ Bem-vinda, Guardiã do Conhecimento ▓▒░", 40);
//    ExibirTextoComEfeito("✧⋯⋯⋯⋯⋯⋯⋯⋯⋯⋯⋯⋯⋯✧", 25);
//    Thread.Sleep(1200);
//    Console.Clear();
//}

//// ✨ Início do programa
//AnimacaoDeAbertura();

//var livroService = new LivroService(new LivroRepository());
//var usuarioService = new UsuarioService(new UsuarioRepository());
//var emprestimoService = new EmprestimoService(
//    new UsuarioRepository(),
//    new LivroRepository(),
//    new EmprestimoRepository());

//bool continuar = true;

//while (continuar)
//{
//    Console.Clear();
//    Console.WriteLine("              . . . . ✦ Bem-vinda ao ✦ . . . .");
//    Console.WriteLine("╔════════════════════════════════════════════════════╗");
//    Console.WriteLine("║               ✷ Scriptoria: Menu Principal ✷      ║");
//    Console.WriteLine("╠════════════════════════════════════════════════════╣");
//    Console.WriteLine("║ 1. Livros                  ⋯⋯ explorar tomos       ║");
//    Console.WriteLine("║ 2. Usuários                ⋯⋯ registrar guardiões  ║");
//    Console.WriteLine("║ 3. Empréstimos             ⋯⋯ conduzir relíquias   ║");
//    Console.WriteLine("║ 0. Sair                    ⋯⋯ desaparecer ✧        ║");
//    Console.WriteLine("╚════════════════════════════════════════════════════╝");
//    Console.WriteLine("             . . . . . . . . . . . . . . . . . . . ✧");
//    Console.Write("\n↳ Escolha um caminho mágico: ");

//    var opcao = Console.ReadLine();

//    switch (opcao)
//    {
//        case "1":
//            MenuLivro.Exibir(livroService);
//            break;
//        case "2":
//            MenuUsuario.Exibir(usuarioService);
//            break;
//        case "3":
//            MenuEmprestimo.Exibir(emprestimoService);
//            break;
//        case "0":
//            continuar = false;
//            Console.Clear();
//            ExibirTextoComEfeito("⟡ As portas da Scriptoria se fecham lentamente... Até breve. ⟡", 40);
//            Thread.Sleep(1000);
//            break;
//        default:
//            Console.ForegroundColor = ConsoleColor.Red;
//            Console.WriteLine("\n✖ Encantação inválida. Pressione qualquer tecla para tentar novamente.");
//            Console.ResetColor();
//            Console.ReadKey();
//            break;
//    }
//}
