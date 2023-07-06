using WebApi_AspNET_Core_Fiap_Fase_01.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi_AspNET_Core_Fiap_Fase_01.Controllers
{
    [Route("api/tarefas")]
    public class TarefaController : Controller
    {
        private readonly ITarefaRepositorio _tarefaRepositorio;
        public TarefaController(ITarefaRepositorio tarefaRepositorio)
        {
            _tarefaRepositorio = tarefaRepositorio;
        }
        [HttpGet]
        public IEnumerable<TarefaItem> GetAll()
        {
            return _tarefaRepositorio.GetAll();
        }

        [HttpGet("{id}", Name = "GetTarefa")]
        public IActionResult GetById(long id)
        {
            var item = _tarefaRepositorio.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] TarefaItem item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            _tarefaRepositorio.Add(item);
            return CreatedAtRoute("GetTarefa", new { id = item.Chave }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] TarefaItem item)
        {
            if (item == null || item.Chave != id)
            {
                return BadRequest();
            }
            var tarefa = _tarefaRepositorio.Find(id);
            if (tarefa == null)
            {
                return NotFound();
            }
            tarefa.EstaCompleta = item.EstaCompleta;
            tarefa.Nome = item.Nome;
            _tarefaRepositorio.Update(tarefa);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var todo = _tarefaRepositorio.Find(id);
            if (todo == null)
            {
                return NotFound();
            }
            _tarefaRepositorio.Remove(id);
            return new NoContentResult();
        }

    }
}
