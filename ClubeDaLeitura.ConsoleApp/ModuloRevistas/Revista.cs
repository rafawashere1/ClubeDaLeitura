using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloCaixas;

namespace ClubeDaLeitura.ConsoleApp.ModuloRevistas
{
    public class Revista : Entidade
    {
        public int Id { get; }
        public string Colecao { get; set; }
        public string NumeroEdicao { get; set; }
        public string AnoRevista{ get; set; }
        public Caixa Caixa { get; set; }

        private static int idRevista = 0;

        public Revista()
        {

        }
        public Revista(string colecao, string numeroEdicao, string anoRevista, Caixa caixa)
        {
            Id = ++idRevista;
            Colecao = colecao;
            NumeroEdicao = numeroEdicao;
            AnoRevista = anoRevista;
            Caixa = caixa;
        }
    }
}
