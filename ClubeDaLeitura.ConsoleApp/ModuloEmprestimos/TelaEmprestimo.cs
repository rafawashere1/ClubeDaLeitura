using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigos;
using ClubeDaLeitura.ConsoleApp.ModuloRevistas;

namespace ClubeDaLeitura.ConsoleApp.ModuloEmprestimos
{
    public class TelaEmprestimo : Tela
    {
        private readonly RepositorioEmprestimo _repositorioEmprestimo;
        private readonly RepositorioAmigo _repositorioAmigo;
        private readonly RepositorioRevista _repositorioRevista;

        private readonly TelaAmigo _telaAmigo;
        private readonly TelaRevista _telaRevista;

        public TelaEmprestimo(RepositorioEmprestimo repositorioEmprestimo, RepositorioAmigo repositorioAmigo, RepositorioRevista repositorioRevista, TelaAmigo telaAmigo, TelaRevista telaRevista)
        {
            _repositorioEmprestimo = repositorioEmprestimo;
            _repositorioAmigo = repositorioAmigo;
            _repositorioRevista = repositorioRevista;
            _telaAmigo = telaAmigo;
            _telaRevista = telaRevista;
        }
        public string ApresentarMenuEmprestimo()
        {
            Console.Clear();

            Console.WriteLine("------ Controle de Emprestimos ------");
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

        public void InserirNovoEmprestimo()
        {
            Emprestimo novoEmprestimo = ObterEmprestimo();

            if (novoEmprestimo == null)
                return;

            _repositorioEmprestimo.Inserir(novoEmprestimo);
        }

        public void EditarEmprestimo()
        {
            Console.WriteLine("Editando Emprestimo: ");

            bool temEmprestimo = VisualizarEmprestimos();

            if (temEmprestimo == false)
                return;

            Console.WriteLine();

            int idSelecionado = EncontrarIdEmprestimo();

            Emprestimo emprestimoAtualizado = ObterEmprestimo();

            _repositorioEmprestimo.Editar(idSelecionado, emprestimoAtualizado);

            Console.WriteLine("Emprestimo atualizado com sucesso!");
        }

        public void ExcluirEmprestimo()
        {
            Console.WriteLine("Excluindo empréstimo: ");

            bool temEmprestimo = VisualizarEmprestimos();

            if (temEmprestimo == false)
                return;

            Console.WriteLine();

            int idSelecionado = EncontrarIdEmprestimo();

            _repositorioEmprestimo.Excluir(idSelecionado);

            Console.WriteLine("Emprestimo Excluído com sucesso!");
        }

        private int EncontrarIdEmprestimo()
        {
            int idSelecionado;
            bool idInvalido;

            do
            {
                Console.Write("Digite o id do empréstimo: ");

                idSelecionado = Convert.ToInt32(Console.ReadLine());

                idInvalido = _repositorioEmprestimo.SelecionarPorId(idSelecionado) == null;

                if (idInvalido)
                {
                    Console.WriteLine();
                    Console.WriteLine("Id inválido, tente novamente");
                    Console.WriteLine();
                }
                    

            } while (idInvalido);

            return idSelecionado;
        }

        public bool VisualizarEmprestimos()
        {
            List<Emprestimo> listaEmprestimos = _repositorioEmprestimo.SelecionarTodos();

            if (listaEmprestimos.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("Nenhum emprestimo cadastrado!");
                return false;
            }

            Console.Clear();

            Console.WriteLine("Visualizando emprestimos:");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("{0,-10} | {1,-40} | {2,-30} | {3,-30} | {4,-30}",
                "Id", "Nome do Amigo", "Coleção da Revista", "Ínicio do empréstimo", "Fim do empréstimo");

            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------------------------");

            Console.ResetColor();

            foreach (Emprestimo e in listaEmprestimos)
            {
                Console.WriteLine("{0,-10} | {1,-40} | {2,-30} | {3,-30} | {4,-30}",
                    e.Id, e.Amigo.Nome, e.Revista.Colecao, e.DataEmprestimo, e.DataDevolucao);
            }

            Console.ResetColor();

            return true;
        }

        private Emprestimo ObterEmprestimo()
        {
            Console.Clear();

            Console.WriteLine("------ Cadastro de Emprestimo ------");
            Console.WriteLine();

            List<Amigo> listaAmigos = _repositorioAmigo.SelecionarTodos();
            List<Revista> listaRevistas = _repositorioRevista.SelecionarTodos();

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

            _telaAmigo.VisualizarAmigos();

            bool continuar = true;

            Amigo amigo = null;

            while (continuar == true)
            {

                amigo = _repositorioAmigo.SelecionarPorId(_telaAmigo.EncontrarIdAmigo());

                if (amigo.temEmprestimo == true)
                {
                    Console.WriteLine("Amigo já tem uma revista emprestada!");
                    return null;
                }

                else
                    break;
            }

            _telaRevista.VisualizarRevistas();

            Revista revista = _repositorioRevista.SelecionarPorId(_telaRevista.EncontrarIdRevista());

            DateTime dataAgora = DateTime.Now;

            Console.WriteLine();

            Console.Write("Digite a data final do empréstimo (DD/MM/YYYY): ");

            DateTime dataFinal = Convert.ToDateTime(Console.ReadLine());

            Emprestimo emprestimo = new(amigo, revista, dataAgora, dataFinal);

            return emprestimo;
        }
    }
}
