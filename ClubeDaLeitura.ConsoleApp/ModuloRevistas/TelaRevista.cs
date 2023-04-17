using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloCaixas;

namespace ClubeDaLeitura.ConsoleApp.ModuloRevistas
{
    public class TelaRevista : Tela
    {
        public static string ApresentarMenuRevista()
        {
            Console.Clear();

            Console.WriteLine();
            Console.WriteLine("Controle de Revistas");
            Console.WriteLine();
            Console.WriteLine("Digite 1 para cadastrar uma revista");
            Console.WriteLine("Digite 2 para editar uma revista");
            Console.WriteLine("Digite 3 para excluir uma revista");
            Console.WriteLine("Digite 4 para visualizar revistas");
            Console.WriteLine();
            Console.WriteLine("Digite S para voltar para o menu principal");

            string opcao = Console.ReadLine();

            return opcao;
        }

        public static void InserirNovaRevista()
        {
            Revista novaRevista = ObterRevista();

            if (novaRevista == null)
                return;

            RepositorioRevista.Inserir(novaRevista);
        }

        public static void EditarRevista()
        {
            Console.WriteLine("Editando Revista: ");

            bool temRevista = VisualizarRevistas();

            if (temRevista == false)
                return;

            Console.WriteLine();

            int idSelecionado = EncontrarIdRevista();

            Revista revistaAtualizada = ObterRevista();

            RepositorioRevista.Editar(idSelecionado, revistaAtualizada);

            Console.WriteLine("Revista atualizada com sucesso!");
        }

        public static void ExcluirRevista()
        {
            Console.WriteLine("Excluindo Revista");

            bool temRevista = VisualizarRevistas();

            if (temRevista == false)
                return;

            Console.WriteLine();

            int idSelecionado = EncontrarIdRevista();

            RepositorioRevista.Excluir(idSelecionado);

            Console.WriteLine("Revista excluída com sucesso!");
        }

        public static bool VisualizarRevistas()
        {
            List<Revista> listaRevistas = RepositorioRevista.SelecionarTodos();

            Console.WriteLine("Visualizando revistas: ");

            if (listaRevistas.Count == 0)
            {
                Console.WriteLine("Nenhuma revista cadastrada!");
                return false;
            }

            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("{0,-10} | {1,-30} | {2,-30} | {3,-30} | {4,-30}", "Id", "Coleção", "Número da Edição", "Ano da Revista", "Caixa");

            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------------");

            Console.ResetColor();

            foreach (Revista r in listaRevistas)
            {
                Console.WriteLine("{0,-10} | {1,-40} | {2,-30} | {3,-30}| {4,-30}",
                    r.Id, r.Colecao, r.NumeroEdicao, r.AnoRevista, r.Caixa.Etiqueta);
            }

            Console.ResetColor();

            return true;
        }

        public static int EncontrarIdRevista()
        {
            int idSelecionado;
            bool idInvalido;

            do
            {
                Console.Write("Digite o id da revista: ");

                idSelecionado = Convert.ToInt32(Console.ReadLine());

                idInvalido = RepositorioRevista.SelecionarPorId(idSelecionado) == null;

                if (idInvalido)
                    Console.WriteLine("Id inválido, tente novamente");

            } while (idInvalido);

            return idSelecionado;
        }

        private static Revista ObterRevista()
        {
            Console.Clear();

            Console.WriteLine("------ Cadastrar Revista ------");
            Console.WriteLine();

            List<Caixa> listaCaixas = RepositorioCaixa.SelecionarTodos();

            if (listaCaixas.Count == 0)
            {
                Console.WriteLine("Não é possível cadastrar uma revista sem cadastrar uma caixa antes!");
                return null;
            }

            Console.Write(">> Digite a coleção da revista: ");
            string colecao = Console.ReadLine();

            Console.Write(">> Digite o número da edição da revista: ");
            string numeroEdicao = Console.ReadLine();

            Console.Write(">> Digite o ano da revista (AAAA): ");
            string anoRevista = Console.ReadLine();

            Console.Clear();

            Console.WriteLine("{0,-10} | {1,-40} | {2,-30} | {3,-30}", "Id", "Etiqueta", "Cor", "Numero");

            Console.WriteLine("---------------------------------------------------------------------------------------------------------------");


            foreach (Caixa c in listaCaixas)
            {
                Console.WriteLine("{0,-10} | {1,-40} | {2,-30} | {3,-30}",
                    c.Id, c.Etiqueta, c.Cor, c.Numero);
            }

            Console.WriteLine();

            Console.Write("Digite o ID da caixa: ");

            int id = Convert.ToInt32(Console.ReadLine());

            Caixa caixa = null;

            foreach (Caixa c in listaCaixas)
            {
                if (c.Id == id)
                {
                    caixa = c;
                    break;
                }
            }

            Revista revista = new(colecao, numeroEdicao, anoRevista, caixa);

            return revista;
        }
    }
}
