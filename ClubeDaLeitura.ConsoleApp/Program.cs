using ClubeDaLeitura.ConsoleApp.ModuloAmigos;
using ClubeDaLeitura.ConsoleApp.ModuloCaixas;
using ClubeDaLeitura.ConsoleApp.ModuloEmprestimos;
using ClubeDaLeitura.ConsoleApp.ModuloRevistas;

namespace ClubeDaLeitura.ConsoleApp
{
    internal class Program
    {
        /*
         requisito 1: arrumar o menu
         requisito 2: arrumar o cadastrar caixas automaticamente
         requisito 3: utilizar melhor a herança
         requisito 4: arrumar a visualizacao do emprestimo
         */
        static void Main(string[] args)
        {
            RepositorioCaixa repositorioCaixa = new();
            //repositorioCaixa.CadastrarAlgumasCaixasAutomaticamente();

            RepositorioAmigo repositorioAmigo = new();
            //repositorioAmigo.CadastrarAlgunsAmigosAutomaticamente();

            RepositorioRevista repositorioRevista = new();
            //repositorioRevista.CadastrarAlgumasRevistasAutomaticamente();

            RepositorioEmprestimo repositorioEmprestimo = new();

            TelaAmigo telaAmigo = new();
            telaAmigo.repositorioAmigo = repositorioAmigo;

            TelaCaixa telaCaixa = new();
            telaCaixa.repositorioCaixa = repositorioCaixa;

            TelaRevista telaRevista = new();
            telaRevista.repositorioRevista = repositorioRevista;
            telaRevista.repositorioCaixa = repositorioCaixa;

            TelaEmprestimo telaEmprestimo = new();
            telaEmprestimo.repositorioRevista = repositorioRevista;
            telaEmprestimo.repositorioEmprestimo = repositorioEmprestimo;
            telaEmprestimo.repositorioAmigo = repositorioAmigo;

            while (true)
            {
                string opcao = ApresentarMenuPrincipal();

                switch (opcao)
                {
                    case "1":

                        string opcaoAmigo = telaAmigo.ApresentarMenuAmigo();

                        if (opcaoAmigo == "1")
                            telaAmigo.InserirNovoAmigo();

                        else if (opcaoAmigo == "2")
                            telaAmigo.EditarAmigo();

                        else if (opcaoAmigo == "3")
                            telaAmigo.ExcluirAmigo();

                        else if (opcaoAmigo == "4")
                        {
                            telaAmigo.VisualizarAmigos();
                            Console.ReadKey();
                        }

                        else if (opcaoAmigo == "S")
                            continue;

                        break;

                    case "2":
                        string opcaoCaixa = telaCaixa.ApresentarMenuCaixa();

                        if (opcaoCaixa == "1")
                            telaCaixa.InserirNovaCaixa();

                        else if (opcaoCaixa == "2")
                            telaCaixa.EditarCaixa();

                        else if (opcaoCaixa == "3")
                            telaCaixa.ExcluirCaixa();

                        else if (opcaoCaixa == "4")
                        {
                            telaCaixa.VisualizarCaixas();
                            Console.ReadKey();
                        }

                        else if (opcaoCaixa == "S")
                            continue;
                        break;

                    case "3":
                        string opcaoRevista = telaRevista.ApresentarMenuRevista();

                        if (opcaoRevista == "1")
                            telaRevista.InserirNovaRevista();

                        else if (opcaoRevista == "2")
                            telaRevista.EditarRevista();

                        else if (opcaoRevista == "3")
                            telaRevista.ExcluirRevista();

                        else if (opcaoRevista == "4")
                        {
                            telaRevista.VisualizarRevistas();
                            Console.ReadKey();
                        }

                        else if (opcaoRevista == "S")
                            continue;
                        break;

                    case "4":
                        string opcaoEmprestimo = telaEmprestimo.ApresentarMenuEmprestimo();

                        if (opcaoEmprestimo == "1")
                            telaEmprestimo.InserirNovoEmprestimo();

                        else if (opcaoEmprestimo == "2")
                            telaEmprestimo.EditarEmprestimo();

                        else if (opcaoEmprestimo == "3")
                            telaEmprestimo.ExcluirEmprestimo();

                        else if (opcaoEmprestimo == "4")
                        {
                            telaEmprestimo.VisualizarEmprestimos();
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