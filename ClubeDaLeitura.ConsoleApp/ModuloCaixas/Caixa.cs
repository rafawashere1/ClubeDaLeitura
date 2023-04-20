using ClubeDaLeitura.ConsoleApp.Compartilhado;

namespace ClubeDaLeitura.ConsoleApp.ModuloCaixas
{
    public class Caixa : Entidade
    {

        public string Etiqueta { get; set; }
        public string Cor { get; set; }
        public int Numero { get; set; }



        public Caixa()
        {

        }

        public Caixa(string etiqueta, string cor, int numero)
        {

            Etiqueta = etiqueta;
            Cor = cor;
            Numero = numero;
        }
    }
}
