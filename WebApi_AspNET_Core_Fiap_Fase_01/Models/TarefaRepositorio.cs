using System.Collections.Generic;
using System.Linq;

namespace WebApi_AspNET_Core_Fiap_Fase_01.Models
{
    public class TarefaRepositorio : ITarefaRepositorio
    {

        private readonly TarefaContext _context;
        public TarefaRepositorio(TarefaContext context)
        {
            _context = context;
            Add(new TarefaItem { Nome = "Item1" });
        }
        public IEnumerable<TarefaItem> GetAll()
        {
            return _context.TarefaItens.ToList();
        }
        public void Add(TarefaItem item)
        {
            _context.TarefaItens.Add(item);
            _context.SaveChanges();
        }
        public TarefaItem Find(long key)
        {
            return _context.TarefaItens.FirstOrDefault(t => t.Chave == key);
        }
        public void Remove(long key)
        {
            var entity = _context.TarefaItens.First(t => t.Chave == key);
            _context.TarefaItens.Remove(entity);
            _context.SaveChanges();
        }
        public void Update(TarefaItem item)
        {
            _context.TarefaItens.Update(item);
            _context.SaveChanges();
        }
    }
}
