namespace DIO.Animes.Interfaces
{
    public interface IRepositorio<T>
    {
        List<T> Lista();
        T RetornaPorId(int id);
        void Insere(T entidade);
        void Exclui(int id);
        void Atualiza(int Id, T entidade);
        int ProximoId();    
    }
}