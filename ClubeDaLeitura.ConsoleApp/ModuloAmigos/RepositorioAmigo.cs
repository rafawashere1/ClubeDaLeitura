using ClubeDaLeitura.ConsoleApp.Compartilhado;

namespace ClubeDaLeitura.ConsoleApp.ModuloAmigos
{
    public class RepositorioAmigo : Repositorio
    {
        public List<Amigo> listaAmigos = new();

        public void Inserir(Amigo novoAmigo)
        {
            listaAmigos.Add(novoAmigo);
        }

        public void Editar(int idSelecionado, Amigo amigoAtualizado)
        {
            Amigo amigo = SelecionarPorId(idSelecionado);

            amigo.Nome = amigoAtualizado.Nome;
            amigo.NomeResponsavel = amigoAtualizado.NomeResponsavel;
            amigo.Telefone = amigoAtualizado.Telefone;
            amigo.Endereco = amigoAtualizado.Endereco;
        }

        public void Excluir(int idSelecionado)
        {
            Amigo amigo = SelecionarPorId(idSelecionado);

            listaAmigos.Remove(amigo);
        }

        public void CadastrarAlgunsAmigosAutomaticamente()
        {
            Amigo amigo = new("Rafael", "José", "(51) 99661-6240", "R. Itapetininga");

            listaAmigos.Add(amigo);
        }

        public List<Amigo> SelecionarTodos()
        {
            return listaAmigos;
        }

        public Amigo SelecionarPorId(int idSelecionado)
        {
            Amigo amigo = null;

            foreach (Amigo a in listaAmigos)
            {
                if (a.Id == idSelecionado)
                {
                    amigo = a;
                    break;
                }
            }

            return amigo;
        }
    }
}
