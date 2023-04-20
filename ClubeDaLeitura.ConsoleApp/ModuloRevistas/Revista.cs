using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloCaixas;

namespace ClubeDaLeitura.ConsoleApp.ModuloRevistas
{
    public class Revista : Entidade
    {

        public string Colecao { get; set; }
        public string NumeroEdicao { get; set; }
        public string AnoRevista{ get; set; }
        public Caixa Caixa { get; set; }


        public Revista()
        {

        }
        public Revista(string colecao, string numeroEdicao, string anoRevista, Caixa caixa)
        {

            Colecao = colecao;
            NumeroEdicao = numeroEdicao;
            AnoRevista = anoRevista;
            Caixa = caixa;
        }
    }
}
