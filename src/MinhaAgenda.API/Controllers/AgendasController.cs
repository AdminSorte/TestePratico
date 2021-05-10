using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MinhaAgenda.API.ViewModel;
using MinhaAgenda.Domain.Interfaces;
using MinhaAgenda.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MinhaAgenda.API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    [Authorize]
    public class AgendasController : ControllerBase
    {
        private readonly IAgendaRepository _AgendaRepository;
        private readonly IAgendaService _agendaService;
        public AgendasController(IAgendaRepository agendaRepository,IAgendaService agendaService)
        {
            _AgendaRepository = agendaRepository;
            _agendaService = agendaService;
        }

        [HttpGet("{Titulo}")]
        public async Task<ActionResult<List<Agenda>>> ObterPorTitulo(string Titulo)
        {
            return Ok(await _AgendaRepository.ObterPorTituloTodos(Titulo));
        }


        [HttpGet]
        public async Task<ActionResult<List<Agenda>>> ObterTodos()
        {
            return Ok(await _AgendaRepository.ObterTodos());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Agenda>> ObterPorId(int id)
        {
            var agenda =  await _agendaService.ObterPorId(id);

            if (agenda == null)
            {
                return NotFound();
            }
            return agenda;
        }


        [HttpPost]
        public async Task<IActionResult> Adicionar(AgendaViewModel viewModelAgenda)
        {

            var agenda = new Agenda(viewModelAgenda.Descricao, viewModelAgenda.Descricao, viewModelAgenda.DataAgedamento);

            var id = await _AgendaRepository.Adicionar(agenda);

            return CreatedAtAction(nameof(ObterPorId), new { id = id }, viewModelAgenda);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Atualizar(AgendaViewModel viewModelAgenda, int id)
        {
            if (id != viewModelAgenda.Id)
            {
                return BadRequest("O id informado não e o mesmo que foi passado");
            }


            if (!await _AgendaRepository.Existe(id)) return NotFound();

            var agenda = new Agenda(viewModelAgenda.Titulo, viewModelAgenda.Descricao, viewModelAgenda.DataAgedamento);
            agenda.Id = viewModelAgenda.Id;
            await _AgendaRepository.Atualizar(agenda);

            return NoContent();
        }


        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Remover(int id)
        {

            if (!await _AgendaRepository.Existe(id)) return NotFound();

            await _AgendaRepository.Remover(id);

            return NoContent();
        }
    }
}
