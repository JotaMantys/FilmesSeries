
using System.Collections.Generic;
using CadastroSeries.Interfaces;

namespace CadastroSeries.Classes 
{
    public class filmeRepositorio : IRepositorio<Filme>
    {

        private List<Filme> lista = new List<Filme>();

//C
        public void Insere(Filme entidade)
        {
            lista.Add(entidade);
        }
//R
        public List<Filme> Lista()
        {
            return lista;
        }

        public Filme RetornaPorId(int id)
        {
            return lista[id];
        }


//U
        public void atualiza(int id, Filme entidade)
        {
            lista[id] = entidade;
        }
//D
        public void Exclui(int id)
        {
            lista[id].excluir();
        }
//Auxiliares
        
        public int ProximoId()
        {
            return lista.Count;
        }


    }
}