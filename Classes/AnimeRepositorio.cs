using DIO.Animes.Interfaces;

namespace DIO.Animes
{
    public class AnimeRepositorio : IRepositorio<Anime>
    {
        private List<Anime> listaAnime = new List<Anime>();
        
        public void Atualiza(int id, Anime entidade)
        {
            listaAnime[id] = entidade;
        }

        public void Exclui(int id)
        {
            listaAnime[id].Excluir();
        }

        public void Insere(Anime entidade)
        {
            listaAnime.Add(entidade);
        }

        public List<Anime> Lista()
        {
            return listaAnime;
        }

        public int ProximoId()
        {
            return listaAnime.Count + 1;
        }

        public Anime RetornaPorId(int id)
        {
            return listaAnime[id];
        }
    }
}