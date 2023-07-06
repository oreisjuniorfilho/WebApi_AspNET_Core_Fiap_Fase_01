using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi_AspNET_Core_Fiap_Fase_01.Models
{
    public class TarefaItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Chave { get; set; }
        public string? Nome { get; set; }
        public Int16 EstaCompleta { get; set; }
    }
}
