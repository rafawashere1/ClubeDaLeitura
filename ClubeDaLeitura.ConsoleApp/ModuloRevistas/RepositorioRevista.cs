using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloCaixas;

namespace ClubeDaLeitura.ConsoleApp.ModuloRevistas
{
   
    public class RepositorioRevista : Repositorio
    {
        private readonly RepositorioCaixa _repositorioCaixa;

        public List<Revista> listaRevistas = new();

        public RepositorioRevista(RepositorioCaixa repositorioCaixa)
        {
            _repositorioCaixa = repositorioCaixa;
        }
        public void Inserir(Revista novaRevista)
        {
            listaRevistas.Add(novaRevista);
        }

        public void CadastrarAlgumasRevistasAutomaticamente()
        {

            Caixa caixa = null;

            foreach (Caixa c in _repositorioCaixa.listaCaixas)
            {
                if (c.Id == 1)
                {
                    caixa = c;
                    break;
                }
            }

            Revista revista = new("Harry Potter", "13", "1999", caixa);

            listaRevistas.Add(revista);
        }

        public List<Revista> SelecionarTodos()
        {
            return listaRevistas;
        }

        public Revista SelecionarPorId(int idSelecionado)
        {
            Revista revista = null;

            foreach (Revista r in listaRevistas)
            {
                if (r.Id == idSelecionado)
                {
                    revista = r;
                    break;
                }
            }

            return revista;
        }

        public void Editar(int idSelecionado, Revista revistaAtualizada)
        {
            Revista revista = SelecionarPorId(idSelecionado);

            revista.Colecao = revistaAtualizada.Colecao;
            revista.NumeroEdicao = revistaAtualizada.AnoRevista;
            revista.AnoRevista = revistaAtualizada.AnoRevista;
            revista.Caixa = revistaAtualizada.Caixa;
        }

        public void Excluir(int idSelecionado)
        {
            Revista revista = SelecionarPorId(idSelecionado);

            listaRevistas.Remove(revista);
        }
    }
}
