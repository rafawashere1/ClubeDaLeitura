using ClubeDaLeitura.ConsoleApp.Compartilhado;

namespace ClubeDaLeitura.ConsoleApp.ModuloCaixas
{
    public class RepositorioCaixa : Repositorio
    {

        public void Inserir(Caixa novaCaixa)
        {
            listaCaixas.Add(novaCaixa);
        }

        public void Editar(int idSelecionado, Caixa caixaAtualizada)
        {
            Caixa caixa = SelecionarPorId(idSelecionado);

            caixa.Etiqueta = caixaAtualizada.Etiqueta;
            caixa.Cor = caixaAtualizada.Cor;
            caixa.Numero = caixaAtualizada.Numero;
        }

        public void Excluir(int idSelecionado)
        {
            Caixa caixa = SelecionarPorId(idSelecionado);

            listaCaixas.Remove(caixa);
        }

        public void CadastrarAlgumasCaixasAutomaticamente()
        {
            Caixa caixa = new("Terror", "Vermelho", 10);

            listaCaixas.Add(caixa);
        }

        public List<Caixa> SelecionarTodos()
        {
            return listaCaixas;
        }

        public Caixa SelecionarPorId(int idSelecionado)
        {
            Caixa caixa = null;

            foreach (Caixa c in listaCaixas)
            {
                if (c.Id == idSelecionado)
                {
                    caixa = c;
                    break;
                }
            }

            return caixa;
        }
    }
}
