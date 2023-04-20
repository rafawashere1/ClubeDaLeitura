namespace ClubeDaLeitura.ConsoleApp.Compartilhado
{
    public class Entidade
    {
        public int Id { get; set; }

        private static int contador = 0;

        public Entidade()
        {
            Id = ++contador;
        }
    }
}
