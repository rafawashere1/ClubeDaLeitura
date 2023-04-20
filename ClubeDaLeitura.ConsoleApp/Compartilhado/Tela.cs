namespace ClubeDaLeitura.ConsoleApp.Compartilhado
{
    public class Tela
    {
        public static void ApresentarMensagem(string mensagem, ConsoleColor cor)
        {
            Console.WriteLine();

            Console.ForegroundColor = cor;

            Console.WriteLine(mensagem);

            Console.ResetColor();

            Console.ReadLine();
        }
    }
}
