using ClubeDaLeitura.ConsoleApp.Compartilhado;

namespace ClubeDaLeitura.ConsoleApp.ModuloAmigos
{
    public class Amigo : Entidade
    {

        public string Nome { get; set; }
        public string NomeResponsavel { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public bool temEmprestimo { get; set; }


        public Amigo()
        {

        }

        public Amigo(string nome, string nomeResponsavel, string telefone, string endereco)
        {

            Nome = nome;
            NomeResponsavel = nomeResponsavel;
            Telefone = telefone;
            Endereco = endereco;
        }
    }
}
