using System.Collections.Generic;

namespace WebApi_AspNET_Core_Fiap_Fase_01.Models
{
    public interface ITarefaRepositorio
    {   
        void Add(TarefaItem item);
        IEnumerable<TarefaItem> GetAll();
        TarefaItem Find(long key);
        void Remove(long key);
        void Update(TarefaItem item);
    }
}
