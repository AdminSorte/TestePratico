using Microsoft.AspNetCore.Mvc;
using MinhaAgenda.Domain.Interfaces;
using MinhaAgenda.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhaAgenda.API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class AgendasController : ControllerBase
    {
        private readonly  IAgendaRepository _AgendaRepository;
        public AgendasController(IAgendaRepository agendaRepository )
        {
            _AgendaRepository = agendaRepository;
        }

        [HttpGet]
        public async Task<ActionResult<Agenda>>  Index()
        {
            return Ok( await _AgendaRepository.ObterTodos());
        }

        [HttpPost]
        public IActionResult Adicionar()
        {
            return Ok();
        }

        [HttpPut]
        public IActionResult Atualizar()
        {
            return Ok();
        }


        [HttpDelete]
        public IActionResult Remover()
        {
            return Ok();
        }
    }
}
