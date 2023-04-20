using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigos;
using ClubeDaLeitura.ConsoleApp.ModuloRevistas;

namespace ClubeDaLeitura.ConsoleApp.ModuloEmprestimos
{
    public class Emprestimo : Entidade
    {

        public Amigo Amigo { get; set; }
        public Revista Revista { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime DataDevolucao { get; set; }



        public Emprestimo()
        {

        }
        public Emprestimo(Amigo amigo, Revista revista, DateTime dataEmprestimo, DateTime dataDevolucao)
        {

            Amigo = amigo;
            Revista = revista;
            DataEmprestimo = dataEmprestimo;
            DataDevolucao = dataDevolucao;
        }
    }
}
