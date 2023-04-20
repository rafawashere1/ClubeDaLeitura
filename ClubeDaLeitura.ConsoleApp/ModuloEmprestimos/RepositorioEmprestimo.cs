using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigos;
using ClubeDaLeitura.ConsoleApp.ModuloRevistas;

namespace ClubeDaLeitura.ConsoleApp.ModuloEmprestimos
{
    public class RepositorioEmprestimo : Repositorio
    {
        private readonly RepositorioAmigo _repositorioAmigo;
        private readonly RepositorioRevista _repositorioRevista;

        public RepositorioEmprestimo(RepositorioAmigo repositorioAmigo, RepositorioRevista repositorioRevista)
        {
            _repositorioAmigo = repositorioAmigo;
            _repositorioRevista = repositorioRevista;
        }

        public List<Emprestimo> listaEmprestimos = new();

        public List<Emprestimo> SelecionarTodos()
        {
            return listaEmprestimos;
        }

        public void Inserir(Emprestimo emprestimo)
        {
            emprestimo.Amigo.temEmprestimo = true; 

            listaEmprestimos.Add(emprestimo);
        }
        public void Editar(int idSelecionado, Emprestimo emprestimoAtualizado)
        {
            Emprestimo emprestimo = SelecionarPorId(idSelecionado);

            emprestimo.Amigo = emprestimoAtualizado.Amigo;
            emprestimo.Revista = emprestimoAtualizado.Revista;
            emprestimo.DataEmprestimo = emprestimoAtualizado.DataEmprestimo;
            emprestimo.DataDevolucao = emprestimoAtualizado.DataDevolucao;
        }

        public void Excluir(int idSelecionado)
        {
            Emprestimo emprestimo = SelecionarPorId(idSelecionado);

            emprestimo.Amigo.temEmprestimo = false;

            listaEmprestimos.Remove(emprestimo);
        }
        public void CadastrarAlgunsEmprestimosAutomaticamente()
        {

            Emprestimo emprestimo = new(_repositorioAmigo.listaAmigos[0], _repositorioRevista.listaRevistas[0], DateTime.Now, Convert.ToDateTime("05/08/2024"));

            listaEmprestimos.Add(emprestimo);
        }

        public Emprestimo SelecionarPorId(int idSelecionado)
        {
            Emprestimo emprestimo = null;

            foreach (Emprestimo e in listaEmprestimos)
            {
                if (e.Id == idSelecionado)
                {
                    emprestimo = e;
                    break;
                }
            }

            return emprestimo;
        }
    }
}
