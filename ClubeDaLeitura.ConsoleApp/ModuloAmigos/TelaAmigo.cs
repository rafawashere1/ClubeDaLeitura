using ClubeDaLeitura.ConsoleApp.Compartilhado;

namespace ClubeDaLeitura.ConsoleApp.ModuloAmigos
{
    public class TelaAmigo : Tela
    {
        private readonly RepositorioAmigo _repositorioAmigo;

        public TelaAmigo(RepositorioAmigo repositorioAmigo)
        {
            _repositorioAmigo = repositorioAmigo;
        }
        public string ApresentarMenuAmigo()
        {
            Console.Clear();

            Console.WriteLine("------ Controle de Amigos ------");
            Console.WriteLine();
            Console.WriteLine("Digite 1 para cadastrar um amigo");
            Console.WriteLine("Digite 2 para editar um amigo");
            Console.WriteLine("Digite 3 para excluir um amigo");
            Console.WriteLine("Digite 4 para visualizar amigos");
            Console.WriteLine();
            Console.WriteLine("Digite S para voltar para o menu principal");

            string opcao = Console.ReadLine();

            return opcao;
        }

        public void InserirNovoAmigo()
        {
            Amigo novoAmigo = ObterAmigo();

            _repositorioAmigo.Inserir(novoAmigo);
        }

        public void EditarAmigo()
        {
            Console.WriteLine("Editando Amigo: ");

            bool temAmigos = VisualizarAmigos();

            if (temAmigos == false)
                return;

            Console.WriteLine();

            int idSelecionado = EncontrarIdAmigo();

            Amigo amigoAtualizado = ObterAmigo();

            _repositorioAmigo.Editar(idSelecionado, amigoAtualizado);

            Console.WriteLine("Amigo editado com sucesso!");
        }
        public void ExcluirAmigo()
        {
            Console.WriteLine("Excluindo Amigo: ");

            bool temAmigos = VisualizarAmigos();

            if (temAmigos == false)
                return;

            Console.WriteLine();

            int idSelecionado = EncontrarIdAmigo();

            _repositorioAmigo.Excluir(idSelecionado);

            Console.WriteLine("Amigo excluído com sucesso!");
        }

        public bool VisualizarAmigos()
        {
            List<Amigo> listaAmigos = _repositorioAmigo.SelecionarTodos();

            Console.Clear();

            Console.WriteLine("Visualizando amigos: ");
            Console.WriteLine();

            if (listaAmigos.Count == 0)
            {
                Console.WriteLine("Nenhum amigo cadastrado!");
                return false;
            }

            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("{0,-10} | {1,-40} | {2,-30} | {3,-30} | {4,-30}", "Id", "Nome", "Nome do Responsável", "Telefone", "Endereço");

            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------------------");

            Console.ResetColor();

            foreach (Amigo a in listaAmigos)
            {
                Console.WriteLine("{0,-10} | {1,-40} | {2,-30} | {3,-30} | {4,-30}",
                    a.Id, a.Nome, a.NomeResponsavel, a.Telefone, a.Endereco);
            }

            Console.ResetColor();

            return true;
        }

        private Amigo ObterAmigo()
        {

            Console.Clear();

            Console.WriteLine("------ Cadastrar Amigo ------");
            Console.WriteLine();

            Console.Write(">> Digite o nome do amigo: ");
            string nome = Console.ReadLine();

            Console.Write(">> Digite o nome do responsável: ");
            string nomeResponsavel = Console.ReadLine();

            Console.Write(">> Digite o telefone: ");
            string telefone = Console.ReadLine();

            Console.Write(">> Digite o endereço: ");
            string endereco = Console.ReadLine();

            Amigo amigo = new(nome, nomeResponsavel, telefone, endereco);

            return amigo;
        }

        public int EncontrarIdAmigo()
        {
            int idSelecionado;
            bool idInvalido;

            do
            {
                Console.Write("Digite o id do amigo: ");

                idSelecionado = Convert.ToInt32(Console.ReadLine());

                idInvalido = _repositorioAmigo.SelecionarPorId(idSelecionado) == null;

                if (idInvalido)
                {
                    Console.WriteLine();
                    Console.WriteLine("Id inválido, tente novamente");
                    Console.WriteLine();
                }
                    

            } while (idInvalido);

            return idSelecionado;
        }
    }
}
