using ClubeDaLeitura.ConsoleApp.Compartilhado;

namespace ClubeDaLeitura.ConsoleApp.ModuloEmprestimos
{
    public class RepositorioEmprestimo : Repositorio
    {
        private static List<Emprestimo> listaEmprestimos = new();

        public static List<Emprestimo> SelecionarTodos()
        {
            return listaEmprestimos;
        }

        public static void Inserir(Emprestimo emprestimo)
        {
            emprestimo.Amigo.temEmprestimo = true; 

            listaEmprestimos.Add(emprestimo);
        }
        public static void Editar(int idSelecionado, Emprestimo emprestimoAtualizado)
        {
            Emprestimo emprestimo = SelecionarPorId(idSelecionado);

            emprestimo.Amigo = emprestimoAtualizado.Amigo;
            emprestimo.Revista = emprestimoAtualizado.Revista;
            emprestimo.DataEmprestimo = emprestimoAtualizado.DataEmprestimo;
            emprestimo.DataDevolucao = emprestimoAtualizado.DataDevolucao;
        }

        public static void Excluir(int idSelecionado)
        {
            Emprestimo emprestimo = SelecionarPorId(idSelecionado);

            emprestimo.Amigo.temEmprestimo = false;

            listaEmprestimos.Remove(emprestimo);
        }

        public static Emprestimo SelecionarPorId(int idSelecionado)
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
