using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigos;
using ClubeDaLeitura.ConsoleApp.ModuloRevistas;

namespace ClubeDaLeitura.ConsoleApp.ModuloEmprestimos
{
    public class TelaEmprestimo : Tela
    {
        public static string ApresentarMenuEmprestimo()
        {
            Console.Clear();

            Console.WriteLine();
            Console.WriteLine("Controle de Emprestimos");
            Console.WriteLine();
            Console.WriteLine("Digite 1 para cadastrar um emprestimo");
            Console.WriteLine("Digite 2 para editar um emprestimo");
            Console.WriteLine("Digite 3 para excluir um emprestimo");
            Console.WriteLine("Digite 4 para visualizar emprestimos");
            Console.WriteLine();
            Console.WriteLine("Digite S para voltar para o menu principal");

            string opcao = Console.ReadLine();

            return opcao;
        }

        public static void InserirNovoEmprestimo()
        {
            Emprestimo novoEmprestimo = ObterEmprestimo();

            if (novoEmprestimo == null)
                return;

            RepositorioEmprestimo.Inserir(novoEmprestimo);
        }

        public static void EditarEmprestimo()
        {
            Console.WriteLine("Editando Emprestimo: ");

            bool temEmprestimo = VisualizarEmprestimos();

            if (temEmprestimo == false)
                return;

            Console.WriteLine();

            int idSelecionado = EncontrarIdEmprestimo();

            Emprestimo emprestimoAtualizado = ObterEmprestimo();

            RepositorioEmprestimo.Editar(idSelecionado, emprestimoAtualizado);

            Console.WriteLine("Emprestimo atualizado com sucesso!");
        }

        public static void ExcluirEmprestimo()
        {
            Console.WriteLine("Excluindo empréstimo: ");

            bool temEmprestimo = VisualizarEmprestimos();

            if (temEmprestimo == false)
                return;

            Console.WriteLine();

            int idSelecionado = EncontrarIdEmprestimo();

            RepositorioEmprestimo.Excluir(idSelecionado);

            Console.WriteLine("Emprestimo Excluído com sucesso!");
        }

        private static int EncontrarIdEmprestimo()
        {
            int idSelecionado;
            bool idInvalido;

            do
            {
                Console.Write("Digite o id do empréstimo: ");

                idSelecionado = Convert.ToInt32(Console.ReadLine());

                idInvalido = RepositorioEmprestimo.SelecionarPorId(idSelecionado) == null;

                if (idInvalido)
                    Console.WriteLine("Id inválido, tente novamente");

            } while (idInvalido);

            return idSelecionado;
        }

        public static bool VisualizarEmprestimos()
        {
            List<Emprestimo> listaEmprestimos = RepositorioEmprestimo.SelecionarTodos();

            if (listaEmprestimos.Count == 0)
            {
                Console.WriteLine("Nenhum emprestimo cadastrado!");
                return false;
            }

            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("{0,-10} | {1,-30} | {2,-30} | {3,-30} | {4,-30}", "Id", "Nome do Amigo", "Coleção da Revista", "Ínicio do empréstimo", "Fim do empréstimo");

            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------------");

            Console.ResetColor();

            foreach (Emprestimo e in listaEmprestimos)
            {
                Console.WriteLine("{0,-10} | {1,-40} | {2,-30} | {3,-30}| {4,-30}",
                    e.Id, e.Amigo.Nome, e.Revista.Colecao, e.DataEmprestimo, e.DataDevolucao);
            }

            Console.ResetColor();

            return true;
        }

        private static Emprestimo ObterEmprestimo()
        {
            Console.Clear();

            Console.WriteLine("------ Cadastro de Emprestimo ------");
            Console.WriteLine();

            List<Amigo> listaAmigos = RepositorioAmigo.SelecionarTodos();
            List<Revista> listaRevistas = RepositorioRevista.SelecionarTodos();

            if (listaAmigos.Count == 0)
            {
                Console.WriteLine("Não é possível cadastrar um empréstimo sem cadastrar um amigo antes!");
                return null;
            }

            if (listaRevistas.Count == 0)
            {
                Console.WriteLine("Não é possível cadastrar um empréstimo sem cadastrar uma revista antes!");
                return null;
            }

            TelaAmigo.VisualizarAmigos();

            bool continuar = true;

            Amigo amigo = null;

            while (continuar == true)
            {

                amigo = RepositorioAmigo.SelecionarPorId(TelaAmigo.EncontrarIdAmigo());

                if (amigo.temEmprestimo == true)
                {
                    Console.WriteLine("Amigo já tem uma revista emprestada!");
                    return null;
                }

                else
                    break;
            }

            TelaRevista.VisualizarRevistas();

            Revista revista = RepositorioRevista.SelecionarPorId(TelaRevista.EncontrarIdRevista());

            DateTime dataAgora = DateTime.Now;

            Console.WriteLine();

            Console.Write("Digite a data final do empréstimo (DD/MM/YYYY): ");

            DateTime dataFinal = Convert.ToDateTime(Console.ReadLine());

            Emprestimo emprestimo = new(amigo, revista, dataAgora, dataFinal);

            return emprestimo;
        }
    }
}
