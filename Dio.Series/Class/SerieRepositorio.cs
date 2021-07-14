using System.Collections.Generic;

namespace Dio.Series
{
    public class SerieRepositorio : Interfaces.IRepositorio<Serie>
    {
        private List<Serie> listSerie = new List<Serie>();

        public void Atualiza(int id, Serie entidade)
        {
            listSerie[id] = entidade;
        }

        public void Exclui(int id)
        {
            listSerie[id].Excluir();
        }

        public void Insere(Serie entidade)
        {
            listSerie.Add(entidade);
        }

        public List<Serie> Lista()
        {
            return listSerie;
        }

        public int ProximoId()
        {
            return listSerie.Count;
        }

        public Serie RetornaPorId(int id)
        {
            return listSerie[id];
        }
    }
}