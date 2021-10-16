
using System.Collections.Generic;
using CadastroSeries.Interfaces;

namespace CadastroSeries.Classes
{
    public class serieRepositorio : IRepositorio<serie>
    {
        private List<serie> listaSerie = new List<serie>();
        

//C
        public void Insere(serie entidade)
        {
            listaSerie.Add(entidade);
        }

//R
        public List<serie> Lista()
        {
            return listaSerie;
        }

        public serie RetornaPorId(int id)
        {
            return listaSerie[id];
        }
//U   
        public void atualiza(int id, serie entidade)
        {
            listaSerie[id] = entidade;
        }

//D
        public void Exclui(int id)
        {
            listaSerie[id].excluir();
        }



//Auxiliares
        public int ProximoId()
        {
            return listaSerie.Count;
        }


    }
}