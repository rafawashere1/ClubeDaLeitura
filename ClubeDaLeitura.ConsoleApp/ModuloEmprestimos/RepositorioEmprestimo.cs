using ClubeDaLeitura.ConsoleApp.Compartilhado;

namespace ClubeDaLeitura.ConsoleApp.ModuloEmprestimos
{
    public class RepositorioEmprestimo : Repositorio
    {

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
