using System.Collections.Generic;

namespace CadastroSeries.Interfaces
{
    public interface IRepositorio<T>
    {
        //C
        void Insere( T entidade);

        //R
        List<T> Lista();

        T RetornaPorId(int id);

        //U

        void atualiza (int id , T entidade);

        //D
        
        void Exclui (int id);

        //auxiliares

        int ProximoId();
    }
}