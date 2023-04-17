using ClubeDaLeitura.ConsoleApp.ModuloAmigos;
using ClubeDaLeitura.ConsoleApp.ModuloCaixas;
using ClubeDaLeitura.ConsoleApp.ModuloEmprestimos;
using ClubeDaLeitura.ConsoleApp.ModuloRevistas;

namespace ClubeDaLeitura.ConsoleApp.Compartilhado
{
    public class Repositorio
    {
        public List<Revista> listaRevistas = new();
        public List<Amigo> listaAmigos = new();
        public List<Emprestimo> listaEmprestimos = new();
        public List<Caixa> listaCaixas = new();
    }
}
