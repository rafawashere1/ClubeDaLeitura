namespace ClubeDaLeitura.ConsoleApp.ModuloCaixas
{
    public class RepositorioCaixa
    {
        public static List<Caixa> listaCaixas = new();

        public static void Inserir(Caixa novaCaixa)
        {
            listaCaixas.Add(novaCaixa);
        }

        public static void Editar(int idSelecionado, Caixa caixaAtualizada)
        {
            Caixa caixa = SelecionarPorId(idSelecionado);

            caixa.Etiqueta = caixaAtualizada.Etiqueta;
            caixa.Cor = caixaAtualizada.Cor;
            caixa.Numero = caixaAtualizada.Numero;
        }

        public static void Excluir(int idSelecionado)
        {
            Caixa caixa = SelecionarPorId(idSelecionado);

            listaCaixas.Remove(caixa);
        }

        public static void CadastrarAlgumasCaixasAutomaticamente()
        {
            Caixa caixa = new("Terror", "Vermelho", 10);

            listaCaixas.Add(caixa);
        }

        public static List<Caixa> SelecionarTodos()
        {
            return listaCaixas;
        }

        public static Caixa SelecionarPorId(int idSelecionado)
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
