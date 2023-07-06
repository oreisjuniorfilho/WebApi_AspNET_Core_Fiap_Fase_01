using Microsoft.EntityFrameworkCore;

namespace WebApi_AspNET_Core_Fiap_Fase_01.Models
{
    public class TarefaContext : DbContext
    {
        public TarefaContext(DbContextOptions<TarefaContext> options)
            : base(options)
        { }
        public DbSet<TarefaItem> TarefaItens { get; set; }
    }
}
