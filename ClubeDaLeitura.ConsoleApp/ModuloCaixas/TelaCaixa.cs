using ClubeDaLeitura.ConsoleApp.Compartilhado;

namespace ClubeDaLeitura.ConsoleApp.ModuloCaixas
{
    public class TelaCaixa : Tela
    {
        public RepositorioCaixa repositorioCaixa = null;
        public string ApresentarMenuCaixa()
        {
            Console.Clear();

            Console.WriteLine("------ Controle de Caixas ------");
            Console.WriteLine();
            Console.WriteLine("Digite 1 para cadastrar uma caixa");
            Console.WriteLine("Digite 2 para editar uma caixa");
            Console.WriteLine("Digite 3 para excluir uma caixa");
            Console.WriteLine("Digite 4 para visualizar caixas");
            Console.WriteLine();
            Console.WriteLine("Digite S para voltar para o menu principal");

            string opcao = Console.ReadLine();

            return opcao;
        }

        public void InserirNovaCaixa()
        {
            Caixa novaCaixa = ObterCaixa();

            repositorioCaixa.Inserir(novaCaixa);
        }

        public void EditarCaixa()
        {
            Console.WriteLine("Editando Caixa: ");

            bool temCaixas = VisualizarCaixas();

            if (temCaixas == false)
                return;

            Console.WriteLine();

            int idSelecionado = EncontrarIdCaixa();

            Caixa caixaAtualizada = ObterCaixa();

            repositorioCaixa.Editar(idSelecionado, caixaAtualizada);

            Console.WriteLine("Caixa editada com sucesso!");
        }

        public void ExcluirCaixa()
        {
            Console.WriteLine("Excluindo Caixa: ");

            bool temCaixas = VisualizarCaixas();

            if (temCaixas == false)
                return;

            Console.WriteLine();

            int idSelecionado = EncontrarIdCaixa();

            repositorioCaixa.Excluir(idSelecionado);

            Console.WriteLine("Caixa excluída com sucesso!");
        }

        public bool VisualizarCaixas()
        {
            List<Caixa> listaCaixas = repositorioCaixa.SelecionarTodos();

            Console.WriteLine("Visualizando caixas: ");

            if (listaCaixas.Count == 0)
            {
                Console.WriteLine("Nenhuma caixa cadastrada!");
                return false;
            }

            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("{0,-10} | {1,-40} | {2,-30} | {3,-30}", "Id", "Etiqueta", "Cor", "Numero");

            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------------");

            Console.ResetColor();

            foreach (Caixa c in listaCaixas)
            {
                Console.WriteLine("{0,-10} | {1,-40} | {2,-30} | {3,-30}",
                    c.Id, c.Etiqueta, c.Cor, c.Numero);
            }

            Console.ResetColor();

            return true;
        }

        private Caixa ObterCaixa()
        {
            Console.Clear();

            Console.WriteLine("------ Cadastrar Caixa ------");
            Console.WriteLine();

            Console.Write(">> Digite a cor da caixa: ");
            string cor = Console.ReadLine();

            Console.Write(">> Digite a etiqueta da caixa: ");
            string etiqueta = Console.ReadLine();

            Console.Write(">> Digite o número da caixa: ");
            int numero = Convert.ToInt32(Console.ReadLine());

            Caixa caixa = new(cor, etiqueta, numero);

            return caixa;
        }

        public int EncontrarIdCaixa()
        {
            int idSelecionado;
            bool idInvalido;

            do
            {
                Console.Write("Digite o id da caixa: ");

                idSelecionado = Convert.ToInt32(Console.ReadLine());

                idInvalido = repositorioCaixa.SelecionarPorId(idSelecionado) == null;

                if (idInvalido)
                    Console.WriteLine("Id inválido, tente novamente");

            } while (idInvalido);

            return idSelecionado;
        }
    }
}
