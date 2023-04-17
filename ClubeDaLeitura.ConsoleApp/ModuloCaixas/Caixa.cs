namespace ClubeDaLeitura.ConsoleApp.ModuloCaixas
{
    public class Caixa
    {
        public int Id { get; }
        public string Etiqueta { get; set; }
        public string Cor { get; set; }
        public int Numero { get; set; }

        private static int idCaixa = 0;

        public Caixa()
        {

        }

        public Caixa(string etiqueta, string cor, int numero)
        {
            Id = ++idCaixa;
            Etiqueta = etiqueta;
            Cor = cor;
            Numero = numero;
        }
    }
}
