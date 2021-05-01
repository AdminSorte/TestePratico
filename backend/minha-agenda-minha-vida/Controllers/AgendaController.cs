using Microsoft.AspNetCore.Mvc;
using minha_agenda_minha_vida.Data;
using minha_agenda_minha_vida.Models;

namespace minha_agenda_minha_vida.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AgendaController: ControllerBase
    {
        private readonly IRepository _repository;
        public AgendaController(IRepository repository){
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Get(){
            var agendas = _repository.GetAllAgendas();
            if(agendas != null)
                return Ok(agendas);
            
            return BadRequest("nao há nenhuma agenda cadastrada");
        }

        [HttpGet("byId")]
        public IActionResult GetById(int id){
            var agenda = _repository.GetAgendaById(id);
            if(agenda != null)
                return Ok(agenda);
            
            return BadRequest("Não há nenhuma agenda com esse Id");
        }

        [HttpPost]
        public IActionResult Post(Agenda agenda){
            _repository.Add<Agenda>(agenda);
            if(_repository.SaveChanges())
                return Created($"api/agenda/{agenda.Id}", agenda);
            
            return BadRequest("Agenda não cadastrada");
        }

        [HttpPut]
        public IActionResult Update(Agenda ag){
            var agenda = _repository.GetAgendaById(ag.Id);
            if(agenda == null) 
                return BadRequest("Agenda não encontrada");

            _repository.Update<Agenda>(agenda);
            if(_repository.SaveChanges())
                return Ok(ag);

            return BadRequest("Informações não atualizadas");
        }

        [HttpDelete]
        public IActionResult Delete(int id){
            var agenda = _repository.GetAgendaById(id);
            if(agenda == null) 
                return BadRequest("Agenda não encontrada");

            _repository.Delete<Agenda>(agenda);
            if(_repository.SaveChanges())
                return Ok("Agenda deletada");

            return BadRequest("Agenda não pôde ser excluída");
        }
        

    }
}