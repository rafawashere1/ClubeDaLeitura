using ClubeDaLeitura.ConsoleApp.ModuloAmigos;
using ClubeDaLeitura.ConsoleApp.ModuloCaixas;
using ClubeDaLeitura.ConsoleApp.ModuloEmprestimos;
using ClubeDaLeitura.ConsoleApp.ModuloRevistas;

namespace ClubeDaLeitura.ConsoleApp
{
    internal class Program
    {

        static void Main(string[] args)
        {
            //RepositorioCaixa.CadastrarAlgumasCaixasAutomaticamente();
            //RepositorioAmigo.CadastrarAlgunsAmigosAutomaticamente();
            //RepositorioRevista.CadastrarAlgumasRevistasAutomaticamente();

            while (true)
            {
                string opcao = ApresentarMenuPrincipal();

                switch (opcao)
                {
                    case "1":

                        string opcaoAmigo = TelaAmigo.ApresentarMenuAmigo();

                        if (opcaoAmigo == "1")
                            TelaAmigo.InserirNovoAmigo();

                        else if (opcaoAmigo == "2")
                            TelaAmigo.EditarAmigo();

                        else if (opcaoAmigo == "3")
                            TelaAmigo.ExcluirAmigo();

                        else if (opcaoAmigo == "4")
                        {
                            TelaAmigo.VisualizarAmigos();
                            Console.ReadKey();
                        }
                           
                        else if (opcaoAmigo == "S")
                            continue;

                        break;

                    case "2":
                        string opcaoCaixa = TelaCaixa.ApresentarMenuCaixa();

                        if (opcaoCaixa == "1")
                            TelaCaixa.InserirNovaCaixa();

                        else if (opcaoCaixa == "2")
                            TelaCaixa.EditarCaixa();

                        else if (opcaoCaixa == "3")
                            TelaCaixa.ExcluirCaixa();

                        else if (opcaoCaixa == "4")
                        {
                            TelaCaixa.VisualizarCaixas();
                            Console.ReadKey();
                        }
                        
                        else if (opcaoCaixa == "S")
                            continue;
                        break;

                    case "3":
                        string opcaoRevista = TelaRevista.ApresentarMenuRevista();

                        if (opcaoRevista == "1")
                            TelaRevista.InserirNovaRevista();

                        else if (opcaoRevista == "2")
                            TelaRevista.EditarRevista();

                        else if (opcaoRevista == "3")
                            TelaRevista.ExcluirRevista();

                        else if (opcaoRevista == "4")
                        {
                            TelaCaixa.VisualizarCaixas();
                            Console.ReadKey();
                        }
                           
                        else if (opcaoRevista == "S")
                            continue;
                        break;

                    case "4":
                        string opcaoEmprestimo = TelaEmprestimo.ApresentarMenuEmprestimo();

                        if (opcaoEmprestimo == "1")
                            TelaEmprestimo.InserirNovoEmprestimo();

                        else if (opcaoEmprestimo == "2")
                            TelaEmprestimo.EditarEmprestimo();

                        else if (opcaoEmprestimo == "3")
                            TelaEmprestimo.ExcluirEmprestimo();

                        else if (opcaoEmprestimo == "4")
                        {
                            TelaEmprestimo.VisualizarEmprestimos();
                            Console.ReadKey();
                        }                           
                        break;

                    case "S":
                        Environment.Exit(0);
                        break;

                    default:
                        break;
                }
            }
        }

        private static string ApresentarMenuPrincipal()
        {
            Console.Clear();

            Console.WriteLine("------- Clube da Leitura ------");
            Console.WriteLine();

            Console.WriteLine("Digite 1 para acessar o menu de amigo");
            Console.WriteLine("Digite 2 para acessar o menu de caixa");
            Console.WriteLine("Digite 3 para acessar o menu de revista");
            Console.WriteLine("Digite 4 para acessar o menu de empréstimos");
            Console.WriteLine();
            Console.WriteLine("Digite S para finalizar o programa");

            string opcao = Console.ReadLine().ToUpper();

            return opcao;
        }
    }
}